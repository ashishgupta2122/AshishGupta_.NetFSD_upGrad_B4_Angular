using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.DataAccess;
using ContactManagement.API.Models;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _repo.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _repo.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newContact = await _repo.AddContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new
            {
                id = newContact.ContactId
            }, newContact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _repo.UpdateContactAsync(id, contact);

            if (!updated)
            {
                return NotFound("Contact not found");
            }

            return Ok("Contact updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var deleted = await _repo.DeleteContactAsync(id);

            if (!deleted)
            {
                return NotFound("Contact not found");
            }

            return Ok("Contact deleted successfully");
        }
    }

}