using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MONACO_ASP.Controllers
{
    public class HomeController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        
		private const String SCREEN_NAME = "Home";

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			ViewData["ScreenName"] = SCREEN_NAME;

			return View();
        }

        public IActionResult Privacy()
        {

			return View();
        }
    }
}