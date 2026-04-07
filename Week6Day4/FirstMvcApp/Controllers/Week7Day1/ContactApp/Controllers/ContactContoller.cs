using Microsoft.AspNetCore.Mvc;
using ContactApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1, FirstName="Ashish", LastName="Gupta", CompanyName="ABC", EmailId="ashishgupta74901@gmail.com", MobileNo=7985285830, Designation="Developer"}
            };

        public ActionResult ShowContacts()
        {
            return View(contacts);
        }

        public ActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            // check null
            return View(contact);
        }

        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);
                return RedirectToAction("ShowContacts");
            }
            return View(contactInfo);
        }
    }
}
