using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        // GET: /feedback
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        // POST: /feedback/submit
        [HttpPost("submit")]
        public IActionResult Submit()
        {
            var name = Request.Form["name"];
            var comments = Request.Form["comments"];
            var ratingStr = Request.Form["rating"];

            int rating = 0;
            int.TryParse(ratingStr, out rating);

            //  Conditional Logic
            if (rating >= 4)
            {
                ViewData["Message"] = $"Thank You {name}!";
            }
            else
            {
                ViewData["Message"] = $"Thanks {name}, we will improve";
            }

            return View("Index");
        }
    }
}