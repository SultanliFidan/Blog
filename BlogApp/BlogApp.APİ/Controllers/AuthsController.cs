using BlogApp.BL.DTOs.CategoryDtos;
using BlogApp.BL.DTOs.UserDTOs;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(IAuthService _service) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _service.LoginAsync(dto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _service.RegisterAsync(dto);
            return Created();
        }
    }
}
