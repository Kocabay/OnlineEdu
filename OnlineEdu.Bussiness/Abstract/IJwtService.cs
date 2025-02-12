using OnlineEdu.DTO.DTOs.LoginDtos;
using OnlineEdu.Entity.Entities;
namespace OnlineEdu.Bussiness.Abstract
{
    public interface IJwtService
    {
        Task<LoginResponseDto> CreateTokenAsync(AppUser user);
    }
}
