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
			Get("/", async (req, res) =>
			{
				res.StatusCode = (int)HttpStatusCode.Conflict;

				await res.WriteAsync($"Hello SinjulMSBH from {nameof(HomeModule)} and Carter .. !!!!");
			});

			After = (ctx) =>
			{
				Console.WriteLine("Catch you later!");

				return Task.CompletedTask;
			};
		}
	}
}
