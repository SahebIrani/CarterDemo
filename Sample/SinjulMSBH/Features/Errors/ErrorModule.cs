namespace CarterSample.Features.Errors
{
	using System;

	using Carter;

	using Microsoft.AspNetCore.Diagnostics;
	using Microsoft.AspNetCore.Http;

	public class ErrorModule : CarterModule
	{
		private const string errorBeaty = @"
			EEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRRR   RRRRRRRRRRRRRRRRR        OOOOOOOOO     RRRRRRRRRRRRRRRRR
			E::::::::::::::::::::ER::::::::::::::::R  R::::::::::::::::R     OO:::::::::OO   R::::::::::::::::R
			E::::::::::::::::::::ER::::::RRRRRR:::::R R::::::RRRRRR:::::R  OO:::::::::::::OO R::::::RRRRRR:::::R
			EE::::::EEEEEEEEE::::ERR:::::R     R:::::RRR:::::R     R:::::RO:::::::OOO:::::::ORR:::::R     R:::::R
			  E:::::E       EEEEEE  R::::R     R:::::R  R::::R     R:::::RO::::::O   O::::::O  R::::R     R:::::R
			  E:::::E               R::::R     R:::::R  R::::R     R:::::RO:::::O     O:::::O  R::::R     R:::::R
			  E::::::EEEEEEEEEE     R::::RRRRRR:::::R   R::::RRRRRR:::::R O:::::O     O:::::O  R::::RRRRRR:::::R
			  E:::::::::::::::E     R:::::::::::::RR    R:::::::::::::RR  O:::::O     O:::::O  R:::::::::::::RR
			  E:::::::::::::::E     R::::RRRRRR:::::R   R::::RRRRRR:::::R O:::::O     O:::::O  R::::RRRRRR:::::R
			  E::::::EEEEEEEEEE     R::::R     R:::::R  R::::R     R:::::RO:::::O     O:::::O  R::::R     R:::::R
			  E:::::E               R::::R     R:::::R  R::::R     R:::::RO:::::O     O:::::O  R::::R     R:::::R
			  E:::::E       EEEEEE  R::::R     R:::::R  R::::R     R:::::RO::::::O   O::::::O  R::::R     R:::::R
			EE::::::EEEEEEEE:::::ERR:::::R     R:::::RRR:::::R     R:::::RO:::::::OOO:::::::ORR:::::R     R:::::R
			E::::::::::::::::::::ER::::::R     R:::::RR::::::R     R:::::R OO:::::::::::::OO R::::::R     R:::::R
			E::::::::::::::::::::ER::::::R     R:::::RR::::::R     R:::::R   OO:::::::::OO   R::::::R     R:::::R
			EEEEEEEEEEEEEEEEEEEEEERRRRRRRR     RRRRRRRRRRRRRRR     RRRRRRR     OOOOOOOOO     RRRRRRRR     RRRRRRR
		";

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

				await res.WriteAsync($"{errorBeaty}\n\nThere has been an error {error} .. !!!!");
			});
		}
	}
}