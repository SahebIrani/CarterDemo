using Carter;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sample.SinjulMSBH.Domain;

namespace Sample
{
	public class Startup
	{
		private readonly AppConfiguration appconfig;
		public Startup(IConfiguration config)
		{
			appconfig = new AppConfiguration();
			config.Bind(appconfig);
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCarter();
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapCarter();
			});
		}
	}
}
