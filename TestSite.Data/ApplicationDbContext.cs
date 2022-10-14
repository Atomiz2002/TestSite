using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TestSite.Data.Entities;

namespace TestSite.Data;

public class ApplicationDbContext : IdentityDbContext {

	public ApplicationDbContext(DbContextOptions options)
		: base(options) {}

	public DbSet<Player> Players { get; set; }

}