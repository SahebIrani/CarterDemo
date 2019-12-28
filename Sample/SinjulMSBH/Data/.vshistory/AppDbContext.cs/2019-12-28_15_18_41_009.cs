using Microsoft.EntityFrameworkCore;

using Sample.SinjulMSBH.Domain;

namespace Sample.SinjulMSBH.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Person> People { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			Person[] people = new Person[]
			{
				new Person {PersonId = 1,Name = "Sinjul" , IsActive = true},
				new Person {PersonId = 1,Name = "MSBH" , IsActive = true},
				new Person {PersonId = 1,Name = "Jack" , IsActive = true},
				new Person { PersonI = 1, Name = "Slater" , IsActive = false},
			};

			modelBuilder.Entity<Person>().HasData(people);
		}
	}
}
