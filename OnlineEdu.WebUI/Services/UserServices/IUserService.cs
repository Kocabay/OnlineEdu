using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
        Task LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
        Task<List<UserViewModel>> GetAllUserAsync();
        Task<List<ResultUserDto>> Get4Teachers();
        Task<ResultUserDto> GetUserByIdAsync(int id);
        Task<List<AssignRoleDto>> GetUserForRoleAssgin(int id);
        Task<int> GetTeacherCount();
        Task<List<ResultUserDto>> GetAllTeachers();
    }
}
