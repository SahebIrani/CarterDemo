using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sample.SinjulMSBH.Data;

namespace Sample
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			IHost host = CreateHostBuilder(args).Build();

			await host.Services.GetRequiredService<AppDbContext>().Database.EnsureCreatedAsync();

			await host.RunAsync();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder

					.ConfigureServices(services =>
					{
						services.AddDbContextPool<AppDbContext>(options =>
							options.UseInMemoryDatabase(nameof(AppDbContext)));
					})

					.UseStartup<Startup>();
				});
	}
}
