using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.TDelete(id);
            return Ok("İletişim Alanı Silindi.");
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newValue = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreate(newValue);
            return Ok("İletişim Alanı Oluşturuldu.");
        }


        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("İletişim Güncellendi.");
        }
    }
}
