namespace Sample.SinjulMSBH.Features.Home
{
	using System.Net;

	using Carter;

	using Microsoft.AspNetCore.Http;

	public class HomeModule : CarterModule
	{
		public HomeModule()
		{
			Before = async context =>
			{
				context.Response.StatusCode = (int)HttpStatusCode.PaymentRequired;

				await context.Response.WriteAsync("HomeModule start Before .. !!!!");

				return true;
			};

			Get("/", async (req, res) =>
			{
				//res.StatusCode = (int)HttpStatusCode.Conflict;

				await res.WriteAsync($"\nHello SinjulMSBH from {nameof(HomeModule)} and Carter .. !!!!\n");
			});

			After = async context =>
			{
				context.Response.StatusCode = (int)HttpStatusCode.Redirect;

				await context.Response.WriteAsync("Catch Home/Index .. !!!!");
			};
		}
	}
}
