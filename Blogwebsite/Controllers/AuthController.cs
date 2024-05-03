using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
