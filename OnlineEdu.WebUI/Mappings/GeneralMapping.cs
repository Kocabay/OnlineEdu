using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.RoleDtos;
using OnlineEdu.WebUI.DTOs.TeacherSocialsDtos;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole,ResultRolDto>().ReverseMap();
            CreateMap<AppRole,CreateRolDto>().ReverseMap();
            CreateMap<AppRole,UpdateRolDto>().ReverseMap();
            CreateMap<AppUser,ResultUserDto>().ReverseMap();
            CreateMap<TeacherSocial,ResultTeacherSocialDto>().ReverseMap();
        }
    }
}
