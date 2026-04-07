using Microsoft.AspNetCore.Mvc;

namespace EMS.AppUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}