using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ServiceLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace ServiceLayer.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

        public IActionResult Index() {
            try {
                //var sessionName = HttpContext.User.Identity.Name.Substring(0, HttpContext.User.Identity.Name.IndexOf("@"));
                //HttpContext.Session.SetString("startSession", sessionName);
            } catch (Exception ex) {

                return BadRequest(ex.Message);
            }

            return View();
        }



        public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}