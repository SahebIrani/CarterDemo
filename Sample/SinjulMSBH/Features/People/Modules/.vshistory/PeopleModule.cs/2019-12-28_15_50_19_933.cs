using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using Carter;
using Carter.ModelBinding;
using Carter.Request;
using Carter.Response;

using FluentValidation.Results;

using Microsoft.EntityFrameworkCore;

using Sample.SinjulMSBH.Data;
using Sample.SinjulMSBH.Domain;
using Sample.SinjulMSBH.Features.People.OpenApi;

namespace Sample.SinjulMSBH.Features.People.Modules
{
	public class PeopleModule : CarterModule
	{
		public PeopleModule(AppDbContext appDbContext)
		{
			Get<GetAllPerson>("/people", async (request, response) =>
			{
				IEnumerable<Person> people =
					await appDbContext.People.AsNoTracking().Where(p => p.IsActive).ToListAsync();

				await response.AsJson(people, new CancellationTokenSource().Token);
			});

			Get<GetPersonById>("/people/{id:int}", async (req, res) =>
			{
				try
				{
					Person person = await appDbContext.People.FindAsync(req.RouteValues.As<int>("PersonId"));

					if (person == null)
						throw new KeyNotFoundException("Person Key Not Found Exception .. !!!!");

					await res.Negotiate(person);
				}
				catch (KeyNotFoundException ex)
				{
					res.StatusCode = (int)HttpStatusCode.NotFound;

					await res.Negotiate(ex);
				}
			});

			Post<CreatePerson>("/people", async (req, res) =>
			{
				(ValidationResult ValidationResult, Person Data) = await req.BindAndValidate<Person>();

				if (!ValidationResult.IsValid)
				{
					res.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

					await res.Negotiate(ValidationResult.GetFormattedErrors());

					return;
				}

				await appDbContext.People.AddAsync(Data);
				await appDbContext.SaveChangesAsync();

				res.StatusCode = (int)HttpStatusCode.Created;

				await res.Negotiate(Data, new CancellationTokenSource().Token);
			});
		}
	}
}
