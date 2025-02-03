using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.DTOs.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto model)
        {
            await _client.PostAsJsonAsync("Subscribers", model);
            return NoContent();
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _client.GetFromJsonAsync<ResultBlogDto>($"Blogs/{id}");
            return View(blog);
        }
        public async Task<IActionResult> BlogsByCategory(int id)
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultBlogDto>>($"Blogs/GetBlogsByCategoryId/{id}");
            ViewBag.categoryName = blogs.Select(x => x.BlogCategory.Name).FirstOrDefault();
            return View(blogs);
        }

    }
}