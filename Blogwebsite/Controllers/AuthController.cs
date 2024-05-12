using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return View("Index");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return View("Index");
            }

            return View("Index");
            
        }
    }
}
