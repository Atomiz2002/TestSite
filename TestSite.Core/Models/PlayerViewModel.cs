using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace TestSite.Core.Models;

public class PlayerViewModel {

	public Guid Id { get; set; }

	[Required] [StringLength(16)]
	public string Username { get; set; }

	[Range(0, int.MaxValue)]
	public int Xp { get; set; }

	[Range(0, int.MaxValue)]
	public int Health { get; set; }

}