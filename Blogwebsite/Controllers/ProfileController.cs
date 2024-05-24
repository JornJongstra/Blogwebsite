using BlogWebsiteCore;
using Classes;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();

			UserCoreManager userCoreManager = new UserCoreManager();
			int sessionUserId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionVariables.SessionKeyUserId));
			ViewBag.User = userCoreManager.GetUser(sessionUserId);
			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
			return View("Index");
		}
	}
}
