using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using BeanAndDrops.Models;


namespace BeanAndDrops.Controllers
{
	public class ProductController : Controller
	{
		private readonly AppDbContext Database;
		public ProductController(AppDbContext database)
		{
			Database = database;

		}

		//This action to show the product was clicked.
		[Route("/products/{id}")]
		public async Task<IActionResult> ViewProduct(string id)
		{
			var product = Database.products.Include("category").FirstOrDefaultAsync(x => x.Product_id == id);

			return await Task.Run(() => View("ViewProduct", product.Result));

		}

		//By using cookies, you can add a product to your shopping cart. 
		[Route("/addtocart/{id}")]
		public async Task<IActionResult> AddToCart(string id)
		{
			var product = Database.products.Find(id);
			var obj = new { id = product.Product_id, price = product.Product_Price };
			var json = JsonSerializer.Serialize(obj);
			var cookie = HttpContext.Request.Cookies["Cart"];
			if (cookie == null)
			{

				HttpContext.Response.Cookies.Append("Cart", json.ToString() + ">");
			}
			else
			{
				HttpContext.Response.Cookies.Append("Cart", HttpContext.Request.Cookies["Cart"] + json.ToString() + ">");
			}
			return await ViewProduct(id);

		}

		//After clicking Buy Now, this Action will display an invoice for the selected product. 
		[Route("/invoice/{id}")]
		public async Task<IActionResult> ShowInv(string id)
		{
			var product = Database.products.Find(id);
			return await Task.Run(() => View("ShowInv", product));

		}

		//This method retrieves the number of products and total price from the cart in order to display them in the layout. 
		public JsonResult getCartDetails()
		{
			var json = HttpContext.Request.Cookies["Cart"];
			if (json == null)
			{
				return Json(null);
			}
			List<string> list = json.Split(">", StringSplitOptions.RemoveEmptyEntries).ToList();
			return Json(list);
		}
	}
}
