using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
