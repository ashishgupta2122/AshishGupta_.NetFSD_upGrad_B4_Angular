using Microsoft.AspNetCore.Mvc;
using EMS.DAL.Models;
using EMS.DAL.Repository;
using System;
using System.Linq;

namespace EMS.AppUI.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly IGenericRepository<SpeakersDetails> _repo;

        public SpeakerController(IGenericRepository<SpeakersDetails> repo)
        {
            _repo = repo;
        }

        // 🔒 LOGIN CHECK
        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetString("UserEmail") != null;
        }

        // 🔒 ADMIN CHECK
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        // ================= INDEX (ALL USERS) =================
        public IActionResult Index()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            var data = _repo.GetAll()?.ToList() ?? new List<SpeakersDetails>();
            return View(data);   // 🔥 LIST SHOW
        }

        // ================= CREATE (ADMIN ONLY) =================
        public IActionResult Create()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult Create(SpeakersDetails model)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
                return View(model);

            model.SpeakerId = Guid.NewGuid();

            _repo.Insert(model);
            _repo.Save();

            return RedirectToAction("Index");
        }

        // ================= DELETE (ADMIN ONLY) =================
        public IActionResult Delete(Guid id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            if (id == Guid.Empty)
                return RedirectToAction("Index");

            try
            {
                _repo.Delete(id);
                _repo.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("DELETE ERROR: " + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}