using Microsoft.AspNetCore.Mvc;
using EMS.DAL.Models;
using EMS.DAL.Repository;

namespace EMS.AppUI.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly IGenericRepository<SpeakersDetails> _repo;

        public SpeakerController(IGenericRepository<SpeakersDetails> repo)
        {
            _repo = repo;
        }

        // 🔹 COMMON SESSION CHECK
        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetString("UserEmail") != null;
        }

        // 🔹 INDEX
        public IActionResult Index()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            var data = _repo.GetAll()?.ToList() ?? new List<SpeakersDetails>();
            return View(data);
        }

        // 🔹 CREATE GET
        public IActionResult Create()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // 🔹 CREATE POST
        [HttpPost]
        public IActionResult Create(SpeakersDetails model)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (string.IsNullOrEmpty(model.SpeakerName))
            {
                ModelState.AddModelError("", "Speaker Name is required");
                return View(model);
            }

            model.SpeakerId = Guid.NewGuid();

            _repo.Insert(model);
            _repo.Save();

            return RedirectToAction("Index");
        }

        // 🔹 DELETE
        public IActionResult Delete(Guid id)
        {
            if (!IsLoggedIn())
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