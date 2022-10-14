using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestSite.Core.Models;
using TestSite.Data.Common;
using TestSite.Data.Entities;

namespace TestSite.Core.Services;

public class PlayerService : IPlayerService {

	private readonly IConfiguration _config;
	private readonly IRepository _repo;

	public PlayerService(IConfiguration config, IRepository repo) {
		_config = config;
		_repo   = repo;
	}

	public async Task<IEnumerable<PlayerViewModel>> GetAll() =>
		await _repo.AllReadonly<Player>().Select(player => ToModel(player)).ToListAsync();

	public async Task<PlayerViewModel> GetById(Guid id) => ToModel(await _repo.GetByIdAsync<Player>(id));

	public async Task Add(PlayerViewModel playerViewModel) => await _repo.AddSaveAsync(ToEntity(playerViewModel));

	public async Task Update(PlayerViewModel playerViewModel) => await _repo.UpdateSaveAsync(ToEntity(playerViewModel));

	public async Task Delete(Guid id) => await _repo.DeleteSaveAsync<Player>(id);

	private static PlayerViewModel ToModel(Player player) =>
		new() {
			Id       = player.Id,
			Username = player.Username,
			Health   = player.Health,
			Xp       = player.Xp
		};

	private static Player ToEntity(PlayerViewModel playerViewModel) =>
		new() {
			Id       = playerViewModel.Id,
			Username = playerViewModel.Username,
			Health   = playerViewModel.Health,
			Xp       = playerViewModel.Xp
		};

}