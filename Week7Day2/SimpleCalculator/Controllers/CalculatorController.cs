using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        //GET: calculator
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        //POST: calculator/add
        [HttpPost("add")]
        public IActionResult Add()
        {
            var num1 = Request.Form["num1"];
            var num2 = Request.Form["num2"];

            int number1 = 0;
            int number2 = 0;

            int.TryParse(num1, out number1);
            int.TryParse(num2, out number2);

            int result = number1 + number2;

            ViewData["Result"] = result;

            return View("Index");

        }
    }
}