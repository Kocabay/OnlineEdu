using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController(ICourseCategoryService _courseCategoryService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseCategoryService.TGetList();
            var courseCategories = _mapper.Map<List<ResultCourseCategoryDto>>(values);
            return Ok(courseCategories);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _courseCategoryService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseCategoryService.TDelete(id);
            return Ok("Kurs Kategori Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            _courseCategoryService.TCreate(newValue);
            return Ok("Yeni Kurs Kategori Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var value = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            _courseCategoryService.TUpdate(value);
            return Ok("Kurs Kategori Alanı Güncellendi");
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _courseCategoryService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetCourseCategoryCount")]
        public IActionResult GetCourseCategoryCount()
        {
            var courseCount = _courseCategoryService.TCount();
            return Ok(courseCount);
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseCategoryService.TShowOnHome(id);
            return Ok("Anasayfada Yayınlandı.");
        }
        [AllowAnonymous]
        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseCategoryService.TDontShowOnHome(id);
            return Ok("Anasayfada Yayınlanmadı.");
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCategoyCount")]
        public IActionResult GetCourseCount()
        {
            var courseCount = _courseCategoryService.TCount();
            return Ok(courseCount);
        }
    }
}
