using System.Collections.Generic;
using System.Net;
using System.Threading;

using Carter;
using Carter.ModelBinding;
using Carter.Response;

using FluentValidation.Results;

using Sample.SinjulMSBH.Domain;
using Sample.SinjulMSBH.Features.People.OpenApi;

namespace Sample.SinjulMSBH.Features.People
{
	public class PeopleModule : CarterModule
	{
		private static IList<Person> people = new List<Person>
		{
			new Person { Name = "Sinjul" , IsActive = true},
			new Person { Name = "MSBH" , IsActive = true},
			new Person { Name = "Jack" , IsActive = true},
			new Person { Name = "Slater" , IsActive = false},
		};

		public PeopleModule()
		{
			Get<GetPeople>("/people", async (request, response) =>
			{
				await response.AsJson(people, new CancellationTokenSource().Token);
			});

			Post("/people", async (req, res) =>
			{
				(ValidationResult ValidationResult, Person Data) = await req.BindAndValidate<Person>();

				if (!ValidationResult.IsValid)
				{
					res.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

					await res.AsJson(ValidationResult.GetFormattedErrors());

					return;
				}

				// Save the person in your database ..
				people.Add(Data);


				res.StatusCode = (int)HttpStatusCode.Created;

				await res.Negotiate(Data);
			});
		}
	}
}
