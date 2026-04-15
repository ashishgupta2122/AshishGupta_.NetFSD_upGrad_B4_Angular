using ContactPaging.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactPaging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 5)
        {
            var result = await _service.GetPagedContactsAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }
}