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
			int sessionUserId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionVariables.SessionKeyUserId));
			ViewBag.User = userCoreManager.GetUser(sessionUserId);
			return View("Index");
		}
	}
}
