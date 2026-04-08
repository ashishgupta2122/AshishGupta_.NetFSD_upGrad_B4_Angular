using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EMS.DAL.Data;
using EMS.DAL.Models;
using System.Linq;

public class ParticipantController : Controller
{
    private readonly EMSDbContext _context;

    public ParticipantController(EMSDbContext context)
    {
        _context = context;
    }

    //  Role Check
    private bool IsParticipant()
    {
        return HttpContext.Session.GetString("Role") == "Participant";
    }

    private IActionResult RedirectToLogin()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }

    //  Dashboard
    public IActionResult Dashboard()
    {
        if (!IsParticipant())
            return RedirectToLogin();

        return View();
    }

    //  My Events
    public IActionResult MyEvents()
    {
        if (!IsParticipant())
            return RedirectToLogin();

        var email = HttpContext.Session.GetString("UserEmail");

        if (string.IsNullOrEmpty(email))
            return RedirectToLogin();

        var events = (from pe in _context.ParticipantEventDetails
                      join e in _context.EventDetails
                      on pe.EventId equals e.EventId
                      where pe.ParticipantEmailId == email
                      select e).ToList();

        return View(events);
    }

    //  My Sessions
    public IActionResult MySessions()
    {
        if (!IsParticipant())
            return RedirectToLogin();

        var email = HttpContext.Session.GetString("UserEmail");

        if (string.IsNullOrEmpty(email))
            return RedirectToLogin();

        var sessions = (from pe in _context.ParticipantEventDetails
                        join s in _context.SessionInfos
                        on pe.EventId equals s.EventId
                        where pe.ParticipantEmailId == email
                        select s).ToList();

        return View(sessions);
    }
}