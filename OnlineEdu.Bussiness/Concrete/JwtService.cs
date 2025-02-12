using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.Bussiness.Configurations;
using OnlineEdu.DTO.DTOs.LoginDtos;
using OnlineEdu.Entity.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineEdu.Bussiness.Concrete
{
    public class JwtService : IJwtService
    {
        private readonly JwtTokenOptions _tokenOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IOptions<JwtTokenOptions> tokenOptions, UserManager<AppUser> userManager)
        {
            _tokenOptions = tokenOptions.Value;
            _userManager = userManager;
        }

        public async Task<LoginResponseDto> CreateTokenAsync(AppUser user)
        {
         
            if (string.IsNullOrEmpty(_tokenOptions.Key))
            {
                throw new ArgumentNullException(nameof(_tokenOptions.Key), "JWT Secret Key boş.");
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Key));

            var userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("fullname",user.FirstName +" "+ user.LastName),


            };
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)

                );

            var handler = new JwtSecurityTokenHandler();

            var responseDto = new LoginResponseDto();

            responseDto.Token = handler.WriteToken(jwtSecurityToken);
            responseDto.ExpireDate = DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes);
            return responseDto;

        }
    }
}
