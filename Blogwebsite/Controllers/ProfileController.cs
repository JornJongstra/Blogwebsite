using BlogWebsiteCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			var authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();

			var userCoreManager = new UserCoreManager();
			var sessionUserId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionVariables.SessionKeyUserId));
			ViewBag.User = userCoreManager.GetUser(sessionUserId);
			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
			return View("Index");
		}
	}
}
