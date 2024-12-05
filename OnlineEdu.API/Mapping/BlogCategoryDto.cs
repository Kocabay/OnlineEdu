using AutoMapper;
using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class BlogCategoryDto : Profile
    {
        public BlogCategoryDto()
        {
            CreateMap<CreateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<ResultBlogCategoryDto, BlogCategory>().ReverseMap();
        }
    }
}
