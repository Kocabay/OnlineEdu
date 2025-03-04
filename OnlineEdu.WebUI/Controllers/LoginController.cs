﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.LoginDtos;
using OnlineEdu.WebUI.DTOs.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineEdu.WebUI.Controllers
{

    public class LoginController : Controller
    {
        private readonly HttpClient _client;

        public LoginController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var result = await _client.PostAsJsonAsync("users/login", userLoginDto);
            if (!result.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(userLoginDto);
            }
            var handler = new JwtSecurityTokenHandler();
            var response = await result.Content.ReadFromJsonAsync<LoginResponseDto>();
            var token = handler.ReadJwtToken(response.Token);
            var claims = token.Claims.ToList();

            if (response.Token != null)
            {
                claims.Add(new Claim("Token", response.Token));
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var autProps = new AuthenticationProperties
                {
                    ExpiresUtc = response.ExpireDate,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), autProps);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            return View(userLoginDto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
