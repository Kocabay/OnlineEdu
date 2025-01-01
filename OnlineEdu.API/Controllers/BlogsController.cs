using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper,IBlogService _blogService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _blogService.TGetById(id);
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
    }
}
