using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategory");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"CourseCategory/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto createCourseCategoryDto)
        {
            await _client.PostAsJsonAsync("CourseCategory", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"CourseCategory/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _client.PutAsJsonAsync("CourseCategory", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("CourseCategory/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("CourseCategory/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}
