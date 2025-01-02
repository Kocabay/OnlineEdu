﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
    public class _UILayoutHeaderContactInfoComponent : ViewComponent
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contact");
            return View(values);
        }
    }
}