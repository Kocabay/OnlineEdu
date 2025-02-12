using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.TeacherSocialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(IGenericService<TeacherSocial> _teacherSocialServices, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("byTeacherId/{id}")]
        public IActionResult GetSocialByTeacherId(int id)
        {

            var values = _teacherSocialServices.TGetFilteredList(I => I.TeacherId == id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _teacherSocialServices.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teacherSocialServices.TDelete(id);
            return Ok("Eğitmen Sosyal Medya Alanı Silindi.");
        }

        [HttpPost]
        public IActionResult Create(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var newValue = _mapper.Map<TeacherSocial>(createTeacherSocialDto);
            _teacherSocialServices.TCreate(newValue);
            return Ok("Yeni Eğitmen Sosyal Medya Alanı Oluşturuldu.");
        }


        [HttpPut]
        public IActionResult Update(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var value = _mapper.Map<TeacherSocial>(updateTeacherSocialDto);
            _teacherSocialServices.TUpdate(value);
            return Ok("Eğitmen Sosyal Medya Alanı Güncellendi.");
        }
    }
}
