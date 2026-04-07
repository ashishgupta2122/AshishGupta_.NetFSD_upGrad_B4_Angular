using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using System.Text.Json;

namespace ProductApp.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private const string sessionKey = "ProductList";

        [HttpGet("")]
        public IActionResult Index()
        {
            var products = GetProducts();
            ViewBag.Products = products;
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add()
        {
            var name = Request.Form["name"];
            var price = Request.Form["price"];
            var quantity = Request.Form["quantity"];

            int p = int.Parse(price);
            int q = int.Parse(quantity);

            var products = GetProducts();

            products.Add(new Product
            {
                Name = name,
                Price = p,
                Quantity = q
            });

            SaveProducts(products);

            ViewBag.Products = products;

            return View("Index");
        }

        private List<Product> GetProducts()
        {
            var data = HttpContext.Session.GetString(sessionKey);

            if (data == null)
                return new List<Product>();

            return JsonSerializer.Deserialize<List<Product>>(data);
        }

        private void SaveProducts(List<Product> products)
        {
            var data = JsonSerializer.Serialize(products);
            HttpContext.Session.SetString(sessionKey, data);
        }
    }
}