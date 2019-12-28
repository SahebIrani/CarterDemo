using Microsoft.EntityFrameworkCore;

using Sample.SinjulMSBH.Domain;

namespace Sample.SinjulMSBH.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Person> People { get; set; }
	}
}
