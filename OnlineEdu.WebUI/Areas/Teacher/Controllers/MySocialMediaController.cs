using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.TeacherSocialsDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MySocialMediaController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HtppClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>("TeacherSocials/byTeacherId/" + user.Id);
            return View(values);
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync($"TeacherSocials/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createTeacherSocialDto.TeacherId = user.Id;
            await _client.PostAsJsonAsync("TeacherSocials", createTeacherSocialDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateTeacherSocialDto>($"TeacherSocials/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            await _client.PutAsJsonAsync("TeacherSocials", updateTeacherSocialDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
