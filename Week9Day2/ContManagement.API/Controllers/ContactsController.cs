using Microsoft.AspNetCore.Mvc;
using ContManagement.API.Data;
using ContManagement.API.Models;
using Microsoft.AspNetCore.RateLimiting;

namespace ContManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("fixed")]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;

            if (!_context.Contacts.Any())
            {
                _context.Contacts.AddRange(
                    new Contact { Name = "Ashish", Email = "ashish@gmail.com", Phone = "1234567890" }
                );
                _context.SaveChanges();
            }
        }

        //GET: /api/contacts
        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }
    }
}