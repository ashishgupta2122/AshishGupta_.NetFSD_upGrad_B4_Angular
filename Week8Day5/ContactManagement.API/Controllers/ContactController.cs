using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactManagement.API.Exceptions;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateContact()
        {
            _logger.LogInformation("Creating contact...");

            return Ok("Contact created");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            _logger.LogInformation($"Fetching contact with ID {id}");

            if (id <= 0)
                throw new ValidationException("Invalid contact ID");

            if (id == 999)
                throw new NotFoundException("Contact not found");

            return Ok("Contact found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _logger.LogWarning($"Deleting contact {id}");

            if (id == 0)
            {
                throw new Exception("Unexpected error");
            }

            return Ok("Deleted successfully");
        }
    }
}