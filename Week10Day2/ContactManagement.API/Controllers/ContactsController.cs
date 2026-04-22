using ContactManagement.API.Models;
using ContactManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetById(id);
            if (contact == null) return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            var created = _service.Add(contact);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            if (!_service.Update(id, contact))
                return NotFound();

            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound();

            return Ok("Deleted");
        }
    }
}