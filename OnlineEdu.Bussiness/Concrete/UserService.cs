using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DTO.DTOs.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Concrete
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager, IMapper _mapper, OnlineEduContext _context) : IUserService
    {
        public async Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto)
        {
            var user = new AppUser
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName
            };
            if (userRegisterDto.Password != userRegisterDto.ConfirmPassword)
            {
                return new IdentityResult();
            }
            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                return result;
            }

            return result;

        }

        public async Task<List<ResultUserDto>> Get4Teachers()
        {
            var users = await _userManager.Users.Include(x => x.TeacherSocials).ToListAsync();
            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).OrderByDescending(x => x.Id).Take(4).ToList();
            return _mapper.Map<List<ResultUserDto>>(teachers);
        }

        public async Task<List<ResultUserDto>> GetAllTeachers()
        {
            var users = await _userManager.Users.Include(x => x.TeacherSocials).ToListAsync();
            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).ToList();
            return _mapper.Map<List<ResultUserDto>>(teachers);
        }

        public async Task<List<AppUser>> GetAllUserAsync()
        {

            return await _userManager.Users.ToListAsync();
        }

        public async Task<int> GetTeacherCount()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return teachers.Count();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> LoginAsync(LoginDto userLoginDto)
        {
            // Kullanıcıyı e-postasına göre bul
            var users = await _userManager.Users.Where(u => u.Email == userLoginDto.Email).ToListAsync();

            // Eğer birden fazla kullanıcı varsa hata döndür
            if (users.Count > 1)
            {
                throw new InvalidOperationException("Multiple users found with the same email address.");
            }

            // Eğer kullanıcı bulunamadıysa
            if (users.Count == 0)
            {
                return null;
            }

            var user = users.First(); // Tek kullanıcıyı al

            // Şifre doğrulama
            var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }

            // Kullanıcı rollerini kontrol et
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return "Admin";
            }

            if (await _userManager.IsInRoleAsync(user, "Teacher"))
            {
                return "Teacher";
            }

            if (await _userManager.IsInRoleAsync(user, "Student"))
            {
                return "Student";
            }

            return "succeeded";
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();

        }
    }
}
