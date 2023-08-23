using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P3.FundamentalData.Web.Models;
using System.Diagnostics;

namespace P3.FundamentalData.Web.Controllers
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
			ViewBag.Exchange = new List<SelectListItem>
					 {
						new SelectListItem { Value = "Any", Text = "Any" },
						new SelectListItem { Value = "AMEX", Text = "AMEX" },
						new SelectListItem { Value = "NYSE", Text = "NYSE" },
						new SelectListItem { Value = "NASDAQ", Text = "NASDAQ" }
					 };
			//var defaultValue = new SelectListItem { Value = "Any", Text = "Any" };
			//ViewBag.Exchange = new SelectList(
			//	new List<SelectListItem>
			//	{
			//		new SelectListItem { Value = "AMEX", Text = "AMEX" },
			//		 new SelectListItem { Value = "NYSE", Text = "NYSE" },
			//		 new SelectListItem { Value = "NASDAQ", Text = "NASDAQ" }
			//	 });
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