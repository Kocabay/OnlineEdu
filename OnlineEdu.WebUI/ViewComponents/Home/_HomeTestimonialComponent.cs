﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TestimonialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeTestimonialComponent : ViewComponent
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonial");
            return View(values);
        }
    }
}
