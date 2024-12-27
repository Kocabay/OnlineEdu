using OnlineEdu.WebUI.DTOs.RoleDtos;

namespace OnlineEdu.WebUI.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ResultRolDto>> GetAllRoleAsync();
        Task<UpdateRolDto> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(CreateRolDto createRolDto);
        Task DeleteRoleAsync(int id);

    }
}
