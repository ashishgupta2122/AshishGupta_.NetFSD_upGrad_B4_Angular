using Microsoft.AspNetCore.Mvc;
using EMS.DAL.Models;
using EMS.DAL.Repository;
using System.Linq;

namespace EMS.AppUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenericRepository<UserInfo> _repo;

        public AccountController(IGenericRepository<UserInfo> repo)
        {
            _repo = repo;
        }

        //  LOGIN GET
        public IActionResult Login()
        {
            return View();
        }

        //  LOGIN POST
        [HttpPost]
        public IActionResult Login(UserInfo model)
        {
            if (string.IsNullOrEmpty(model.EmailId) || string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Error = "Enter Email and Password";
                return View(model);
            }

            var user = _repo.GetAll()
                .FirstOrDefault(u =>
                    u.EmailId.ToLower().Trim() == model.EmailId.ToLower().Trim() &&
                    u.Password.Trim() == model.Password.Trim());

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.EmailId);
                HttpContext.Session.SetString("UserRole", user.Role);

                if (user.Role == "Admin")
                    return RedirectToAction("Dashboard", "Admin");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid Email or Password";
            return View(model);
        }

        //  REGISTER GET
        public IActionResult Register()
        {
            return View();
        }

        //  REGISTER POST
        [HttpPost]
        public IActionResult Register(UserInfo model)
        {
            if (string.IsNullOrEmpty(model.EmailId) ||
                string.IsNullOrEmpty(model.UserName) ||
                string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Error = "All fields are required";
                return View(model);
            }

            model.EmailId = model.EmailId.Trim();
            model.UserName = model.UserName.Trim();
            model.Password = model.Password.Trim();

            var exists = _repo.GetAll()
                .Any(u => u.EmailId.ToLower() == model.EmailId.ToLower());

            if (exists)
            {
                ViewBag.Error = "Email already exists";
                return View(model);
            }

            model.Role = "Participant";

            _repo.Insert(model);
            _repo.Save();

            return RedirectToAction("Login");
        }

        //  LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}