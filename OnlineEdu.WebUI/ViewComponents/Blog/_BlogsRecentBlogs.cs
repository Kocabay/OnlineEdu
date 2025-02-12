using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogsRecentBlogs:ViewComponent
    {
        private readonly HttpClient _client;

        public _BlogsRecentBlogs(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/getlast4blogs");
            return View(values);
        }
    }
}
