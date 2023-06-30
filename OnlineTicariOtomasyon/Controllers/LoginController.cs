using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Admin p)
		{
			if (p.Username == "admin" && p.Password == "admin")
			{

			}
			return View();
		}
	}
}
