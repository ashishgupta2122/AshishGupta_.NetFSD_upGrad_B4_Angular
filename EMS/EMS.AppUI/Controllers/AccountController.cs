using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EMS.DAL.Data;
using EMS.DAL.Models;
using EMS.AppUI.Models;
using System.Linq;

public class AccountController : Controller
{
    private readonly EMSDbContext _context;

    public AccountController(EMSDbContext context)
    {
        _context = context;
    }

    // LOGIN GET
    public IActionResult Login()
    {
        return View();
    }

    //  LOGIN POST
    [HttpPost]
    public IActionResult Login(LoginModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = _context.UserInfos
            .FirstOrDefault(u => u.EmailId == model.Email && u.Password == model.Password);

        if (user != null)
        {
            HttpContext.Session.SetString("UserEmail", user.EmailId);
            HttpContext.Session.SetString("Role", user.Role);

            if (user.Role == "Admin")
                return RedirectToAction("Dashboard", "Admin");
            else
                return RedirectToAction("Dashboard", "Participant");
        }

        ViewBag.Error = "Invalid Login";
        return View();
    }

    //  REGISTER GET
    public IActionResult Register()
    {
        return View();
    }

    //  REGISTER POST (FULL FIXED )

    [HttpPost]
    public IActionResult Register(UserInfo model)
    {
        //  DEBUG
        Console.WriteLine("Register Hit");

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model Invalid");
            return View(model);
        }

        var existingUser = _context.UserInfos
            .FirstOrDefault(u => u.EmailId == model.EmailId);

        if (existingUser != null)
        {
            ViewBag.Error = "Email already exists";
            return View(model);
        }

        model.Role = "Participant";

        _context.UserInfos.Add(model);
        _context.SaveChanges();

        Console.WriteLine("User Saved");

        HttpContext.Session.SetString("UserEmail", model.EmailId);
        HttpContext.Session.SetString("Role", model.Role);

        return RedirectToAction("Dashboard", "Participant");
    }
    //  LOGOUT
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}