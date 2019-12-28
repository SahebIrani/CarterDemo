using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using Carter;
using Carter.ModelBinding;
using Carter.Response;

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
				await response.AsJson(people.Where(p => p.IsActive), new CancellationTokenSource().Token);
			});

			Post<AddPeople>("/people", async (req, res) =>
			{
				var result = await req.BindAndValidate<Person>();

				if (!result.ValidationResult.IsValid)
				{
					res.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

					await res.Negotiate(result.ValidationResult.GetFormattedErrors());

					return;
				}

				people.Add(result.Data);

				res.StatusCode = (int)HttpStatusCode.Created;

				await res.Negotiate(result.Data);
			});
		}
	}
}
