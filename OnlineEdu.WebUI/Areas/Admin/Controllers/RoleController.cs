﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DataAccess.Migrations;
using OnlineEdu.WebUI.DTOs.RoleDtos;
using OnlineEdu.WebUI.Services.RoleServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class RoleController(IRoleService _roleService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _roleService.GetAllRoleAsync();
            return View(values);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRolDto createRolDto)
        {
            await _roleService.CreateRoleAsync(createRolDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("Index");
        }
    }
}
