using System.Collections.Generic;

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
		public Startup(IConfiguration configuration)
		{
			AppConfiguration = new AppConfiguration();
			configuration.Bind(AppConfiguration);
		}

		public AppConfiguration AppConfiguration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCarter(options =>
			{
				options.OpenApi.DocumentTitle = AppConfiguration.CarterOptions.OpenApi.DocumentTitle;
				options.OpenApi.ServerUrls = new[] { "https://localhost:5001" };
				options.OpenApi.Securities = new Dictionary<string, OpenApiSecurity>
				{
					{ "BearerAuth", new OpenApiSecurity { BearerFormat = "JWT", Type = OpenApiSecurityType.http, Scheme = "bearer" } },
					{ "ApiKey", new OpenApiSecurity { Type = OpenApiSecurityType.apiKey, Name = "X-API-KEY", In = OpenApiIn.header } }
				};
				options.OpenApi.GlobalSecurityDefinitions = new[] { "BearerAuth" };
			});

			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app.UseExceptionHandler("/errorhandler");

			app.UseRouting();

			app.UseSwaggerUI(opt =>
			{
				opt.RoutePrefix = "openapi/ui";
				opt.SwaggerEndpoint("/openapi", "SinjulMSBH CarterDemo OpenAPI .. !!!!");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapCarter();
			});
		}
	}
}
