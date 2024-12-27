using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.RoleDtos;

namespace OnlineEdu.WebUI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole,ResultRolDto>().ReverseMap();
            CreateMap<AppRole,CreateRolDto>().ReverseMap();
            CreateMap<AppRole,UpdateRolDto>().ReverseMap();
        }
    }
}
