using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Repository.Interfaces;
using DataAccessLayer.Models;

namespace AppUILayer.Controllers;

[Route("contact")]
public class ContactController : Controller
{
    private readonly IContactRepository _repo;

    public ContactController(IContactRepository repo)
    {
        _repo = repo;
    }

    // ✅ Show All
    [HttpGet("")]
    [HttpGet("all")]
    public IActionResult ShowContacts()
    {
        var data = _repo.GetAllContacts();
        return View(data);
    }

    // ✅ Details
    [HttpGet("details/{id}")]
    public IActionResult GetContactById(int id)
    {
        var contact = _repo.GetContactById(id);
        if (contact == null)
            return NotFound();

        return View("Details", contact);   // 🔥 FIX
    }

    // ✅ Add (GET)
    [HttpGet("add")]
    public IActionResult AddContact()
    {
        LoadDropdowns();
        return View();
    }

    // ✅ Add (POST)
    [HttpPost("add")]
    public IActionResult AddContact(ContactInfo contact)
    {
        if (ModelState.IsValid)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        LoadDropdowns();
        return View(contact);
    }

    // ✅ Edit (GET)
    [HttpGet("edit/{id}")]
    public IActionResult EditContact(int id)
    {
        var contact = _repo.GetContactById(id);
        if (contact == null)
            return NotFound();

        LoadDropdowns();
        return View(contact);
    }

    // ✅ Edit (POST)
    [HttpPost("edit")]
    public IActionResult EditContact(ContactInfo contact)
    {
        if (ModelState.IsValid)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        LoadDropdowns();
        return View(contact);
    }

    // ✅ Delete
    [HttpGet("delete/{id}")]
    public IActionResult DeleteContact(int id)
    {
        _repo.DeleteContact(id);
        return RedirectToAction("ShowContacts");
    }

    // 🔥 Dropdown
    private void LoadDropdowns()
    {
        ViewBag.CompanyList = new SelectList(_repo.GetAllCompanies(), "CompanyId", "CompanyName");
        ViewBag.DepartmentList = new SelectList(_repo.GetAllDepartments(), "DepartmentId", "DepartmentName");
    }
}