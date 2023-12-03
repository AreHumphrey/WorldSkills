using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View("../Views/public/index.html");
		}
	}
}
