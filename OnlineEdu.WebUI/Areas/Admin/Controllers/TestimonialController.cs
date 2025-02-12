using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.TestimonialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly HttpClient _client;

        public TestimonialController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("Testimonial");
            return View(values);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _client.DeleteAsync($"Testimonial/{id}");
            return RedirectToAction(nameof(Index));
        }


        public IActionResult CreateTestimonial()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _client.PostAsJsonAsync("Testimonial", createTestimonialDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateTestimonialDto>($"Testimonial/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _client.PutAsJsonAsync("Testimonial", updateTestimonialDto);
            return RedirectToAction(nameof(Index));
        }

    }
}
