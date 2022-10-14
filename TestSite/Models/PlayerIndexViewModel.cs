using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using TestSite.Core.Models;

namespace TestSite.Models;

public class PlayerIndexViewModel {

	[ValidateNever]
	public IEnumerable<PlayerViewModel> Players { get; set; }
	public PlayerViewModel Player { get; set; }

}