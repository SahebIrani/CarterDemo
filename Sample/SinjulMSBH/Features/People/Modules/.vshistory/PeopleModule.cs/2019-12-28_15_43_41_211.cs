using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using Carter;
using Carter.ModelBinding;
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

				await response.AsJson(people.Where(p => p.IsActive), new CancellationTokenSource().Token);
				await response.Negotiate(people, new CancellationTokenSource().Token);
			});

			Post<CreatePerson>("/people", async (req, res) =>
			{
				(ValidationResult ValidationResult, Person Data) = await req.BindAndValidate<Person>();

				if (!ValidationResult.IsValid)
				{
					res.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

					await res.Negotiate(ValidationResult.GetFormattedErrors());
					//await res.AsJson(ValidationResult.GetFormattedErrors());

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
