using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TeacherSocialsDtos;
using OnlineEdu.WebUI.Services.TokenService;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MySocialMediaController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public MySocialMediaController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>("TeacherSocials/byTeacherId/" + userId);
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
            var userId = _tokenService.GetUserId;
            createTeacherSocialDto.TeacherId = userId;
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
