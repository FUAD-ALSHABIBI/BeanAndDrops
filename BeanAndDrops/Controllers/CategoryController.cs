using BeanAndDrops.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;

namespace BeanAndDrops.Controllers
{
	public class CategoryController : Controller
	{
		private readonly AppDbContext Database;

		public CategoryController(AppDbContext dbContext)
		{
			Database = dbContext;
		}

		//This action will show all products in the selected category.
		[Route("/cate/{id}")]
		public IActionResult show(string id)
		{
			dynamic items = new ExpandoObject();
			items.Category = Database.category.Where(x => x.Category_Id == id).ToList();
			items.Products = Database.products.Where(x => x.category.Category_Id == id).ToList();
			return View(items);
		}

		//Send category details to the JS file for the show list in layout.
		public JsonResult GetCategory()
		{
			var Category = Database.category.ToList();
			List<string> list = new List<string>();
			foreach (var item in Category)
			{
				var ob = new { id = item.Category_Id, name = item.Category_Name };
				var json = JsonSerializer.Serialize(ob);
				list.Add(json);
			}

			return Json(list);
		}
	}
}
