using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCourseCategoryComponent : ViewComponent
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategory/GetActiveCategories");
            return View(values);
        }
    }
}
