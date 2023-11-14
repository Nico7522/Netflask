using Microsoft.AspNetCore.Mvc;
using Netflask.Web.Models;
using System.Diagnostics;

namespace Netflask.Web.Controllers
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
			HomeModel hm = new HomeModel();
			HeaderMovie SnowQueen = new HeaderMovie()
			{
				Title = "La reine des neige",
				Categorie = "Tout public",
				Description = "dqsdsdqsdsqdqsdqsdqsdqsdqsdsqdqsdq",
				Directors =  "Chris Buck, Jennifer Lee",
				Genre = "Animation",
				PictureUrl = "/images/rdn.jpg",
				Rating = 7.4,
				ReleaseDate = new DateTime(2013, 12, 4),
			};
			hm.HeaderMovie = SnowQueen;
			return View(hm);
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