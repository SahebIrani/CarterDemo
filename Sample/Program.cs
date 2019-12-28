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

			using (IServiceScope scope = host.Services.CreateScope())
				await scope.ServiceProvider.GetRequiredService<AppDbContext>()
					.Database.EnsureCreatedAsync();

			await host.RunAsync();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices(services =>
				{
					services.AddDbContextPool<AppDbContext>(options =>
						options.UseInMemoryDatabase(nameof(AppDbContext)));
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
