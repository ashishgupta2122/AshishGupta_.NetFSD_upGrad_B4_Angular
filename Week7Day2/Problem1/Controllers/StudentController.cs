using Microsoft.AspNetCore.Mvc;

namespace Problem1.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        //GET: student/register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        //POST: student/register
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            return RedirectToAction("Display", new
            {
                name = name,
                age = age,
                course = course
            });
        }

        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
            // Passing data using ViewBag
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}