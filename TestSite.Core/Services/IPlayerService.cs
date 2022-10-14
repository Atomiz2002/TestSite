using TestSite.Core.Models;

namespace TestSite.Core.Services;

public interface IPlayerService {

	Task<IEnumerable<PlayerViewModel>> GetAll();

	Task<PlayerViewModel> GetById(Guid id);

	Task Add(PlayerViewModel playerViewModel);

	Task Delete(Guid id);

	Task Update(PlayerViewModel playerViewModel);

}