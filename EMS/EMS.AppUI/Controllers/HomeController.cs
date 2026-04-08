using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EMS.AppUI.Models;
using EMS.DAL.Data;
using EMS.DAL.Models;
using System.Linq;
using System;

namespace EMS.AppUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly EMSDbContext _context;

        public HomeController(EMSDbContext context)
        {
            _context = context;
        }

        // HOME PAGE → ONLY ACTIVE EVENTS
        public IActionResult Index()
        {
            var events = _context.EventDetails
                .Where(e => e.Status == "Active")
                .ToList();

            return View(events);
        }

        // EVENT DETAILS
        public IActionResult EventDetails(Guid id)
        {
            var ev = _context.EventDetails
                .FirstOrDefault(e => e.EventId == id);

            if (ev == null)
                return NotFound();

            return View(ev);
        }

        // REGISTER EVENT (PARTICIPANT ONLY)
        public IActionResult RegisterEvent(Guid id)
        {
            //  Role Check
            if (HttpContext.Session.GetString("Role") != "Participant")
            {
                return RedirectToAction("Login", "Account");
            }

            var email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }

            // ❗ Already Registered Check
            var exists = _context.ParticipantEventDetails
                .FirstOrDefault(x => x.EventId == id && x.ParticipantEmailId == email);

            if (exists == null)
            {
                _context.ParticipantEventDetails.Add(new ParticipantEventDetails
                {
                    EventId = id,
                    ParticipantEmailId = email,
                    IsAttended = false
                });

                _context.SaveChanges();
            }

            return RedirectToAction("MyEvents", "Participant");
        }

        //  PRIVACY
        public IActionResult Privacy()
        {
            return View();
        }

        //  ERROR
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}