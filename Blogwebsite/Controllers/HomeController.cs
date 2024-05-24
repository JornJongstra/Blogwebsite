using Blogwebsite.Models;
using BlogWebsite;
using BlogWebsite.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blogwebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //SessionController sessionController = new SessionController(HttpContext);
            ViewBag.username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
            //ViewBag.session = sessionController.GetSessionInfo();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
