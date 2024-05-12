using BlogWebsiteCore;
using Classes;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			UserCoreManager userCoreManager = new UserCoreManager();
			ViewBag.User = userCoreManager.GetUser(1);
			return View("Index");
		}
	}
}
