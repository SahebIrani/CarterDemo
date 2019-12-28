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
				new Person { PersonId = 1, Name = "Sinjul" ,Age = 26, IsActive = true  },
				new Person { PersonId = 2, Name = "MSBH" , Age = 26,  IsActive = true  },
				new Person { PersonId = 3, Name = "Jack" , Age = 26,  IsActive = true  },
				new Person { PersonId = 4, Name = "Slater" ,Age = 26, IsActive = false },
			};

			modelBuilder.Entity<Person>().HasData(people);
		}
	}
}
