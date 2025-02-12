﻿using Microsoft.AspNetCore.Identity;
using OnlineEdu.DTO.DTOs.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto);
        Task<string> LoginAsync(LoginDto userLoginDto);
        Task LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
        Task<List<AppUser>> GetAllUserAsync();
        Task<List<ResultUserDto>> Get4Teachers();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<int> GetTeacherCount();
        Task<List<ResultUserDto>> GetAllTeachers();
    }
}
