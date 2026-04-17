using ContactService.Models;
using ContactService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add(Contact contact)
        {
            await _service.Add(contact);
            return Ok("Created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Contact contact)
        {
            await _service.Update(contact);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok("Deleted");
        }
    }
}