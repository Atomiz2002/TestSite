using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TestSite.Core.Contracts;
using TestSite.Core.Models;

namespace TestSite.Core.Services;

public class PlayerService : IPlayerService {

	private readonly IConfiguration _config;

	public PlayerService(IConfiguration config) => _config = config;

	public async Task<IEnumerable<Player>> GetAll() {
		string path = _config.GetValue<string>("DataFiles:Players");
		string data = await File.ReadAllTextAsync(path);

		return JsonConvert.DeserializeObject<IEnumerable<Player>>(data)!;
	}

}