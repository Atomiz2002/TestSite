using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestSite.Data.Entities;

public class Player {

	[Key]
	public Guid Id { get; set; }

	[Required] [StringLength(16)]
	public string Username { get; set; } = null!;

	[Required]
	public int Xp { get; set; }

	[Required]
	public int Health { get; set; }

	public bool Disabled { get; set; }

}