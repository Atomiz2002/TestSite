using Microsoft.AspNetCore.Mvc;
using TestSite.Core.Models;
using TestSite.Core.Services;
using TestSite.Models;

namespace TestSite.Controllers;

public class PlayerController : Controller {

	private readonly IPlayerService _service;

	public PlayerController(IPlayerService service) => _service = service;

	public async Task<IActionResult> Index() {
		PlayerIndexViewModel model = new();
		model.Players = await _service.GetAll();
		model.Player  = new();

		return View(model);
	}

	public async Task<IActionResult> Create(PlayerIndexViewModel model) {
		model.Players = model.Players ?? await _service.GetAll();
		model.Player  = model.Player  ?? new();

		if (!ModelState.IsValid) return View(nameof(Index), model);

		if (model.Player.Id == Guid.Empty)
			await _service.Add(model.Player);
		else
			await _service.Update(model.Player);

		model.Players = await _service.GetAll();

		return RedirectToAction(nameof(Index));
	}

	public async Task<IActionResult> Edit(Guid id) {
		if (!ModelState.IsValid)
			return RedirectToAction(nameof(Index));

		PlayerIndexViewModel model = new();
		model.Players = await _service.GetAll();
		model.Player  = await _service.GetById(id);

		return View(nameof(Index), model);
	}

	public async Task<IActionResult> Delete(Guid id) {
		await _service.Delete(id);

		return RedirectToAction(nameof(Index));
	}

}