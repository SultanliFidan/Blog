using BlogApp.BL.DTOs.CategoryDtos;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _service) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Byte(string value)
        {
            return Ok(HashHelper.HashPasword(value));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Verify(string value,string hash)
        {
            return Ok(HashHelper.VerifyPassword(value,hash));
        }
        //[HttpGet("[action]")]
        //public async Task<IActionResult> Byte(string value)
        //{
        //    return Ok(HashHelper.SHA256HashByte(value));
        //}
        //[HttpGet("[action]")]
        //public async Task<IActionResult> String(string value)
        //{
        //    return Ok(HashHelper.SHA256Hash(value));
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

       
    }
}
