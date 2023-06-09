using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
	public class AppDbContext : DbContext
	{
		protected readonly IConfiguration Configuration;
		public AppDbContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseInMemoryDatabase("InMem");
		}

		public DbSet<Platform> Platforms { get; set; }
	}
}