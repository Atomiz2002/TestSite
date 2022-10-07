using Microsoft.AspNetCore.Mvc;
using TestSite.Core.Contracts;

namespace TestSite.Controllers;

public class PlayerController : Controller {

	private readonly IPlayerService _service;

	public PlayerController(IPlayerService service) => _service = service;

	[HttpGet]
	public IActionResult Index() => View();

	[HttpPost]
	public async Task<IActionResult> Stats() => View(await _service.GetAll());

}