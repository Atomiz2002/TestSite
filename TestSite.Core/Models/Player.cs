using System.ComponentModel.DataAnnotations;

namespace TestSite.Core.Models;

public class Player {

	public Guid Id { get; set; }

	[Required] [StringLength(16)]
	public string Username { get; set; } = null!;

	[Range(0, int.MaxValue)]
	public int Xp { get; set; }

	[Range(0, int.MaxValue)]
	public int Health { get; set; }

}