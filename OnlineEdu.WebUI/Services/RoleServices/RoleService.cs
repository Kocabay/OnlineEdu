using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.RoleDtos;

namespace OnlineEdu.WebUI.Services.RoleServices
{
    public class RoleService(RoleManager<AppRole> _roleManager, IMapper _mapper) : IRoleService
    {
        public async Task CreateRoleAsync(CreateRolDto createRolDto)
        {
            var role = _mapper.Map<AppRole>(createRolDto);
           var result =  await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
        }

        public async Task<List<ResultRolDto>> GetAllRoleAsync()
        {
            var values = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<List<ResultRolDto>>(values);
        }

        public async Task<UpdateRolDto> GetRoleByIdAsync(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UpdateRolDto>(value);
        }
    }
}
