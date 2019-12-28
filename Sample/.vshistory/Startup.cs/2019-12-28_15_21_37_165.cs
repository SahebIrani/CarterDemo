using System.Collections.Generic;

using Carter;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Sample.SinjulMSBH.Data;
using Sample.SinjulMSBH.Domain;

namespace Sample
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			AppConfiguration = new AppConfiguration();
			configuration.Bind(AppConfiguration);
		}

		public AppConfiguration AppConfiguration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContextPool<AppDbContext>(
				options =>
						  options.UseInMemoryDatabase(nameof(AppDbContext)));

			services.AddCarter(options =>
			{
				options.OpenApi.DocumentTitle = AppConfiguration.CarterOptions.OpenApi.DocumentTitle;

				options.OpenApi.ServerUrls = new[] { AppConfiguration.CarterOptions.OpenApi.ServerUrls };

				options.OpenApi.GlobalSecurityDefinitions =
								new[] { AppConfiguration.CarterOptions.OpenApi.GlobalSecurityDefinitions };

				options.OpenApi.Securities = new Dictionary<string, OpenApiSecurity>
				{
					{ "BearerAuth", new OpenApiSecurity { BearerFormat = "JWT",
						Type = OpenApiSecurityType.http, Scheme = "bearer" } },

					{ "ApiKey", new OpenApiSecurity { Type = OpenApiSecurityType.apiKey,
						Name = "X-API-KEY", In = OpenApiIn.header } }
				};
			});

			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseExceptionHandler("/errorhandler");

			app.UseRouting();

			app.UseSwaggerUI(opt =>
			{
				opt.RoutePrefix = "openapi/ui";
				opt.SwaggerEndpoint("/openapi", "SinjulMSBH CarterDemo OpenAPI Sample .. !!!!");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapCarter();
			});
		}
	}
}
