using CategoryService.Models;
using CategoryService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CategoryService.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _service.Add(category);
            return Ok("Created");
        }
    }
}