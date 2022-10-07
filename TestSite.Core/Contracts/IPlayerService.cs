using TestSite.Core.Models;

namespace TestSite.Core.Contracts;

public interface IPlayerService {

	Task<IEnumerable<Player>> GetAll();

}