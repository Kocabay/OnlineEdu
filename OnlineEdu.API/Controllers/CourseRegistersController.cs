using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.CourseRegisterDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistersController(IGenericService<CourseRegister> _courseRegisterService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetMyCourses/{id}")]
        public IActionResult GetMyCourses(int userId)
        {
            var value = _courseRegisterService.TGetFilteredList(x => x.AppUserId == userId);
            var mappedValue = _mapper.Map<List<ResultCourseRegisterDto>>(value);
            return Ok(mappedValue);
        }

        [HttpPost]
        public IActionResult RegisterToCourse(CreateCourseRegisterDto model)
        {
            var newCourseRegister = _mapper.Map<CourseRegister>(model);
            _courseRegisterService.TCreate(newCourseRegister);
            return Ok("Kursa Kayıt Başarılı.");
        }

        [HttpPut]
        public IActionResult UpadteCourseRegister(UpdateCourseRegisterDto model)
        {
            var updatedCourseRegister = _mapper.Map<CourseRegister>(model);
            _courseRegisterService.TUpdate(updatedCourseRegister);
            return Ok("Kurs Kaydı Güncellendi.");
        }

        [HttpGet("{id")]
        public IActionResult GetById(int id)
        {
            var value = _courseRegisterService.TGetById(id);
            var mappedValue = _mapper.Map<ResultCourseRegisterDto>(value);
            return Ok(mappedValue);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourseRegister(int id)
        {
            _courseRegisterService.TDelete(id);
            return Ok("Kurs Kaydı Silindi.");
        }

    }
}
