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

				return false;
			};

			Get("/", async (req, res) =>
			{
				res.StatusCode = (int)HttpStatusCode.Conflict;

				await res.WriteAsync($"Hello SinjulMSBH from {nameof(HomeModule)} and Carter .. !!!!");
			});

			After = context =>
			{
				Console.WriteLine("Catch Home/Index .. !!!!");

				return Task.CompletedTask;
			};
		}
	}
}
