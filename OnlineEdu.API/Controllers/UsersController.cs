using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, IJwtService _jwtService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("Bu Email sistemde kayıtlı değil");
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest("Kullanıcı adı ve şifre hatalı");
            }

            var token = await _jwtService.CreateTokenAsync(user);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                await _userManager.AddToRoleAsync(user, "Student");
                return Ok("Kullanıcı kaydı başarılı.");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("TeacherList")]
        public async Task<IActionResult> TeacherList()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(teachers);
        }


        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var student = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(student);
        }

        [HttpGet("Get4Teachers")]
        public async Task<IActionResult> Get4Teachers()
        {
            var users = await _userManager.Users.Include(x => x.TeacherSocials).ToListAsync();
            var teachers = users.Where(user => _userManager.IsInRoleAsync(user, "Teacher").Result).OrderByDescending(x => x.Id).Take(4).ToList();
            return Ok(teachers);
        }
    }
}
