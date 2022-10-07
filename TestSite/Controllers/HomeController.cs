using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestSite.Models;

namespace TestSite.Controllers;

public class HomeController : Controller {

	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger) => _logger = logger;

	[HttpGet]
	public IActionResult Index() => View();

	[HttpGet]
	public IActionResult Privacy() => View();

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() => View(new ErrorViewModel
		                                     {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

}