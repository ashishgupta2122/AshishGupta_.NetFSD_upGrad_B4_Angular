using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.DAL.Models;
using EMS.DAL.Repository;
using System.Linq;

namespace EMS.AppUI.Controllers
{
    public class SessionController : Controller
    {
        private readonly IGenericRepository<SessionInfo> _repo;
        private readonly IGenericRepository<EventDetails> _eventRepo;
        private readonly IGenericRepository<SpeakersDetails> _speakerRepo;

        public SessionController(
            IGenericRepository<SessionInfo> repo,
            IGenericRepository<EventDetails> eventRepo,
            IGenericRepository<SpeakersDetails> speakerRepo)
        {
            _repo = repo;
            _eventRepo = eventRepo;
            _speakerRepo = speakerRepo;
        }

        //  SESSION CHECK
        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetString("UserEmail") != null;
        }

        //  INDEX
        public IActionResult Index()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            var sessions = _repo.GetAll()?.ToList() ?? new List<SessionInfo>();
            var events = _eventRepo.GetAll()?.ToList() ?? new List<EventDetails>();
            var speakers = _speakerRepo.GetAll()?.ToList() ?? new List<SpeakersDetails>();

            //  MANUAL JOIN (IMPORTANT)
            foreach (var s in sessions)
            {
                s.Event = events.FirstOrDefault(e => e.EventId == s.EventId);
                s.Speaker = speakers.FirstOrDefault(sp => sp.SpeakerId == s.SpeakerId);
            }

            return View(sessions);
        }

        //  CREATE GET
        public IActionResult Create()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            LoadDropdowns();
            return View();
        }

        //  CREATE POST (FINAL FIXED)
        [HttpPost]
        public IActionResult Create(SessionInfo model)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            Console.WriteLine("CREATE HIT");

            //  VALIDATION FIX
            if (model.EventId == Guid.Empty)
                ModelState.AddModelError("EventId", "Event is required");

            if (model.SessionStart == default)
                ModelState.AddModelError("SessionStart", "Start time required");

            if (model.SessionEnd == default)
                ModelState.AddModelError("SessionEnd", "End time required");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("MODEL INVALID");
                LoadDropdowns();
                return View(model);
            }

            model.SessionId = Guid.NewGuid();

            _repo.Insert(model);
            _repo.Save();

            Console.WriteLine("SESSION SAVED");

            return RedirectToAction("Index");
        }

        //  DELETE
        public IActionResult Delete(Guid id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id != Guid.Empty)
            {
                _repo.Delete(id);
                _repo.Save();
            }

            return RedirectToAction("Index");
        }

        //  COMMON METHOD (BEST PRACTICE)
        private void LoadDropdowns()
        {
            ViewBag.Events = new SelectList(
                _eventRepo.GetAll()?.ToList() ?? new List<EventDetails>(),
                "EventId", "EventName"
            );

            ViewBag.Speakers = new SelectList(
                _speakerRepo.GetAll()?.ToList() ?? new List<SpeakersDetails>(),
                "SpeakerId", "SpeakerName"
            );
        }
    }
}