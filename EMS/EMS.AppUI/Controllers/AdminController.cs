using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EMS.DAL.Data;
using EMS.DAL.Models;
using System.Linq;
using System;

namespace EMS.AppUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly EMSDbContext _context;

        public AdminController(EMSDbContext context)
        {
            _context = context;
        }

        // Common Admin Check
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        private IActionResult RedirectToLogin()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // Dashboard
        public IActionResult Dashboard()
        {
            if (!IsAdmin()) return RedirectToLogin();
            return View();
        }

        // ================= EVENT =================

        public IActionResult CreateEvent()
        {
            if (!IsAdmin()) return RedirectToLogin();
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDetails model)
        {
            if (!IsAdmin()) return RedirectToLogin();

            model.EventId = Guid.NewGuid(); // 🔥 IMPORTANT
            model.Status = "Draft";

            _context.EventDetails.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        //  DELETE EVENT
        public IActionResult DeleteEvent(Guid id)
        {
            if (!IsAdmin()) return RedirectToLogin();

            var ev = _context.EventDetails.FirstOrDefault(e => e.EventId == id);

            if (ev != null)
            {
                _context.EventDetails.Remove(ev);
                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }

        // ================= SPEAKER =================

        public IActionResult AddSpeaker()
        {
            if (!IsAdmin()) return RedirectToLogin();
            return View();
        }

        [HttpPost]
        public IActionResult AddSpeaker(SpeakersDetails model)
        {
            if (!IsAdmin()) return RedirectToLogin();

            model.SpeakerId = Guid.NewGuid(); // 🔥 IMPORTANT

            _context.SpeakersDetails.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        //  DELETE SPEAKER
        public IActionResult DeleteSpeaker(Guid id)
        {
            if (!IsAdmin()) return RedirectToLogin();

            var sp = _context.SpeakersDetails.FirstOrDefault(s => s.SpeakerId == id);

            if (sp != null)
            {
                _context.SpeakersDetails.Remove(sp);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Speaker");
        }

        // ================= SESSION =================

        public IActionResult AddSession()
        {
            if (!IsAdmin()) return RedirectToLogin();

            ViewBag.Events = _context.EventDetails.ToList();
            ViewBag.Speakers = _context.SpeakersDetails.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddSession(SessionInfo model)
        {
            if (!IsAdmin()) return RedirectToLogin();

            model.SessionId = Guid.NewGuid(); // 🔥 IMPORTANT

            _context.SessionInfos.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        //  DELETE SESSION
        public IActionResult DeleteSession(Guid id)
        {
            if (!IsAdmin()) return RedirectToLogin();

            var session = _context.SessionInfos.FirstOrDefault(s => s.SessionId == id);

            if (session != null)
            {
                _context.SessionInfos.Remove(session);
                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }

        // ================= PUBLISH EVENT =================

        public IActionResult PublishEvent(Guid id)
        {
            if (!IsAdmin()) return RedirectToLogin();

            var ev = _context.EventDetails.FirstOrDefault(e => e.EventId == id);

            if (ev != null)
            {
                ev.Status = "Active";
                _context.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }
    }
}