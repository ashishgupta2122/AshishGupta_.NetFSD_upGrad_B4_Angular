using Microsoft.AspNetCore.Mvc;
using EMS.DAL.Models;
using EMS.DAL.Repository;

namespace EMS.AppUI.Controllers
{
    public class EventController : Controller
    {
        private readonly IGenericRepository<EventDetails> _repo;

        public EventController(IGenericRepository<EventDetails> repo)
        {
            _repo = repo;
        }

        //  LOGIN CHECK
        private bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail"));
        }

        public IActionResult Index()
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Login", "Account");

            var data = _repo.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult Create(EventDetails model)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
            {
                model.EventId = Guid.NewGuid();
                model.Status = "Active";
                _repo.Insert(model);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Login", "Account");

            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction("Index");
        }
    }
}