using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Repository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.DbContext;
using System.Linq;

namespace AppUILayer.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;
        private readonly AppDbContext _context;

        public ContactController(IContactRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet("ShowContacts")]
        public IActionResult ShowContacts()
        {
            return View(_repo.GetAllContacts());
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            return View(_repo.GetContactById(id));
        }


        [HttpGet("AddContact")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");

            return View();
        }

        [HttpPost("AddContact")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);


            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName", contact.CompanyId);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", contact.DepartmentId);

            return View(contact);
        }

        [HttpPost("EditContact")]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
}