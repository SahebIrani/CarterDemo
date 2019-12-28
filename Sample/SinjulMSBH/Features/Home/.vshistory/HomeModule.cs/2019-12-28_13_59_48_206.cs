namespace Sample.SinjulMSBH.Features.Home
{

	using Carter;

	using Microsoft.AspNetCore.Http;

	public class HomeModule : CarterModule
	{
		public HomeModule()
		{
			Before = async context =>
			{
				await context.Response.WriteAsync("HomeModule start Before .. !!!!");

				return true;
			};

			Get("/", async (req, res) =>
			{
				await res.WriteAsync($"\nHello SinjulMSBH from {nameof(HomeModule)} and Carter .. !!!!\n");
			});

			After = async context =>
			{
				await context.Response.WriteAsync("Catch Home/Index .. !!!!");
			};
		}
	}
}
