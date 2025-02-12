using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper,IBlogService _blogService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }

        [AllowAnonymous]
        [HttpGet("getlast4blogs")]
        public IActionResult GetLast4Blogs()
        {
            var values = _blogService.TGetLastFourBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
        [AllowAnonymous]

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _blogService.TGetBlogCategory(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Kategori Alanı Silindi.");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {

            var newValue = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(newValue);
            return Ok("Yeni Kategori Alanı Oluşturuldu.");
        }


        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(value);
            return Ok("Kategori Alanı Güncellendi.");
        }

        [HttpGet("GetBlogByWriterId/{id}")]
        public IActionResult GetBlogByWriterId(int id)
        {
            var values = _blogService.TGetBlogsWtihCategoriesByWriterId(id);
            var mappedValues = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(mappedValues);
        }

        [AllowAnonymous]
        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var blogCount = _blogService.TCount();
            return Ok(blogCount);
        }
        [AllowAnonymous]

        [HttpGet("GetBlogsByCategoryId/{id}")]
        public IActionResult GetBlogsByCategoryId(int id)
        {
            var blogs = _blogService.TGetBlogsByCategoryId(id);
            return Ok(blogs);
        }
    }
}
