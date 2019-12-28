namespace CarterSample.Features.Errors
{
	using System;

	using Carter;

	using Microsoft.AspNetCore.Diagnostics;
	using Microsoft.AspNetCore.Http;

	public class ErrorModule : CarterModule
	{
		public ErrorModule()
		{
			Get("/error", (req, res) =>
			{
				throw new Exception("oops baby .. !!!!");
			});

			Get("/errorhandler", async (req, res) =>
			{
				string error = string.Empty;

				IExceptionHandlerFeature feature = req.HttpContext.Features.Get<IExceptionHandlerFeature>();

				if (feature != null)
				{
					if (feature.Error is ArgumentNullException) res.StatusCode = 402;

					error = feature.Error.ToString();
				}

				await res.WriteAsync($"There has been an error \n {error}");
			});
		}
	}
}