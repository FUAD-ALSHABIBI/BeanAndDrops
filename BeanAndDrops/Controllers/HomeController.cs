using BeanAndDrops.Models;
using BeanAndDrops.Models.AddView;
using BeanAndDrops.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BeanAndDrops.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext Database;

		public HomeController(ILogger<HomeController> logger, AppDbContext database)
		{
			_logger = logger;
			Database = database;

		}

		//This action is used to redirect the main page after the site has been run. 
		public IActionResult Index()
		{
			return RedirectToAction("main");
		}

		//This Action for Main page
		[Route("/Main")]
		public IActionResult main()
		{
			var product = Database.products.Include("category").ToList();
			return View(product);
		}

		//This Action displays all products added to the cart via cookies. 
		[Route("/Cart")]
		public IActionResult ShowCart()
		{
			List<Product> prolist = new List<Product>();
			var cookie = HttpContext.Request.Cookies["Cart"];
			if (cookie != null)
			{
				List<string> list = cookie.Split(">", StringSplitOptions.RemoveEmptyEntries).ToList();

				foreach (var item in list)
				{
					var obj = JsonConvert.DeserializeObject<GetterProduct>(item);
					prolist.Add(Database.products.Include("category").FirstOrDefault(x => x.Product_id == obj.id));
				}
			}
			return View(prolist);
		}

		//This action completes the order and displays the outcome. 
		[Route("/makeOrder")]
		public IActionResult Done()
		{

			List<Product> prolist = new List<Product>();
			double total = 0;
			double vat = 0;
			double net = 0;
			var cookie = HttpContext.Request.Cookies["Cart"];
			if (cookie != null)
			{
				List<string> list = cookie.Split(">", StringSplitOptions.RemoveEmptyEntries).ToList();

				foreach (var item in list)
				{
					var obj = JsonConvert.DeserializeObject<GetterProduct>(item);
					prolist.Add(Database.products.Include("category").FirstOrDefault(x => x.Product_id == obj.id));
					total += prolist[prolist.Count - 1].Product_Price;
				}
			}
			vat = total * 0.15;
			vat = Math.Truncate(vat * 1000) / 1000;
			net = vat + total;
			var invoice = new { Total = total, Vat = vat, Net = net, List = prolist };
			return View(invoice);
		}

		//This method for searching for products when written in the search bar and sent to JS
		public JsonResult SearchProducts(string product)
		{
			var p = Database.products.Where(x => x.Product_Name.Contains(product));
			return Json(p);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}