using AutoMapper;
using OnlineEdu.DTO.DTOs.TeacherSocialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class TeacherSocialMapping:Profile
    {
        public TeacherSocialMapping()
        {
            CreateMap<TeacherSocial,ResultTeacherSocialDto>();
            CreateMap<TeacherSocial,UpdateTeacherSocialDto>();
            CreateMap<TeacherSocial, CreateTeacherSocialDto>();
        }
    }
}
