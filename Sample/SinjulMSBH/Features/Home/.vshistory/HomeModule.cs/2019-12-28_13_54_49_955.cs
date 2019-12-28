namespace Sample.SinjulMSBH.Features.Home
{
	using System;
	using System.Net;
	using System.Threading.Tasks;

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

			After = context =>
			{
				context.Response.StatusCode = (int)HttpStatusCode.Redirect;

				Console.WriteLine("Catch Home/Index .. !!!!");

				return Task.CompletedTask;
			};
		}
	}
}
