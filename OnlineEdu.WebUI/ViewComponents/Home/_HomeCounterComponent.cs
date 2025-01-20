﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCounterComponent(IUserService _userService) : ViewComponent
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
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
