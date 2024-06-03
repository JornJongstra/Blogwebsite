using BlogWebsiteCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Classes;

namespace BlogWebsite.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsNotAuthenticated()) return NotFound();

			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
			return View();
        }
        public IActionResult Register()
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsNotAuthenticated()) return NotFound();

			ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
			return View();
        }
		public IActionResult Logout()
		{
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsAuthenticated()) return NotFound();

			HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login(string email, string password)
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsNotAuthenticated()) return NotFound();

			if (string.IsNullOrWhiteSpace(email))
            {
                return RedirectToAction("Index");
			}
            if (string.IsNullOrWhiteSpace(password))
            {
                return RedirectToAction("Index");
			}

            AuthCoreManager authCoreManager = new AuthCoreManager();

            var user = authCoreManager.LoginCheck(email, password);

			if (user != null)
			{
				HttpContext.Session.SetString(SessionVariables.SessionKeyUsername, user.Username);
				HttpContext.Session.SetString(SessionVariables.SessionKeySessionId, Guid.NewGuid().ToString());
				HttpContext.Session.SetInt32(SessionVariables.SessionKeyUserId, user.Id);

				return RedirectToAction("Index", "Home");
			} else
			{
				return RedirectToAction("Index");
			}
        }
        public IActionResult RegisterUser(string username ,string email, string password) 
        {
			AuthUser authController = new AuthUser(HttpContext);
			if (!authController.IsNotAuthenticated()) return NotFound();

			if (string.IsNullOrWhiteSpace(email))
			{
				return RedirectToAction("Register");
			}
			if (string.IsNullOrWhiteSpace(password))
			{
				return RedirectToAction("Register");
			}
			if (string.IsNullOrWhiteSpace(username))
			{
				return RedirectToAction("Register");
			}
			
			AuthCoreManager authCoreManager= new AuthCoreManager();
			User user = new User(username, password, email);

			if (authCoreManager.RegisterUser(user))
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Register");

		}
    }
}
