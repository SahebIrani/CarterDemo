using Microsoft.EntityFrameworkCore;

namespace Sample.SinjulMSBH.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
		{
		}
	}
}
