using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using TestSite.Core.Contracts;
using TestSite.Core.Models;

namespace TestSite.Api.Controllers;

/// <inheritdoc />
[ApiController]
[Route("api/[controller]")]
public class PlayerController : Controller {

	private readonly IPlayerService _playerService;

	/// <inheritdoc />
	public PlayerController(IPlayerService playerService) => _playerService = playerService;

	/// <summary>Retrieves all players</summary>
	/// <returns>Ok with all players</returns>
	[HttpGet]
	[Produces(MediaTypeNames.Application.Json)]
	[ProducesResponseType(typeof(IEnumerable<Player>), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAll() => Ok(await _playerService.GetAll());

}