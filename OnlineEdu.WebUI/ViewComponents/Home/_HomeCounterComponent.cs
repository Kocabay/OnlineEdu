﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCounterComponent : ViewComponent
    {
        private readonly HttpClient _client;
 
        public _HomeCounterComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.blogCount = await _client.GetFromJsonAsync<int>("blogs/GetBlogCount");
            ViewBag.courseCount = await _client.GetFromJsonAsync<int>("courses/GetCourseCount");
            ViewBag.courseCategoryCount = await _client.GetFromJsonAsync<int>("CourseCategory/GetCourseCategoyCount");
            ViewBag.testimonialCount = await _client.GetFromJsonAsync<int>("Testimonial/GetTestimonialoyCount");
            return View();
        }
    }
}
