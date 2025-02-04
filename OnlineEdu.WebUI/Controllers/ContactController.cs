﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.DTOs.MessageDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contact");
            ViewBag.map = values.Select(x => x.MapUrl).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("messages", createMessageDto);
            return NoContent();
        }

        public async Task<PartialViewResult> ContanctMap()
        {
            
            return PartialView();
        }
    }
}
