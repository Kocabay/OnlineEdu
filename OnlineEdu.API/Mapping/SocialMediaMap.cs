using AutoMapper;
using OnlineEdu.DTO.DTOs.SocialMediaDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class SocialMediaMap:Profile
    {
        public SocialMediaMap()
        {
            CreateMap<CreateSocialMediaDto,SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto,SocialMedia>().ReverseMap();
        }
    }
}
