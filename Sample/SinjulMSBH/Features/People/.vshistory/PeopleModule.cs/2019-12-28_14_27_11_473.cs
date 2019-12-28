using Carter;
using Carter.Response;

using Sample.SinjulMSBH.Domain;
using Sample.SinjulMSBH.Features.People.OpenApi;

namespace Sample.SinjulMSBH.Features.People
{
	public class PeopleModule : CarterModule
	{
		public PeopleModule()
		{
			this.Get<GetPeople>("/people", async (request, response) =>
			{
				Person[] people = new[]
				{
					new Person { Name = "Sinjul" , IsActive = true},
					new Person { Name = "MSBH" , IsActive = true},
					new Person { Name = "Jack" , IsActive = true},
					new Person { Name = "Slater" , IsActive = false},
				};

				await response.AsJson(people);
			});

			this.Post("/people", async (req, res) =>
			{
				var result = await req.BindAndValidate<CastMember>();

				if (!result.ValidationResult.IsValid)
				{
					await res.AsJson(result.ValidationResult.GetFormattedErrors());
					return;
				}

				await res.WriteAsync("OK");
			});
		}
	}
}
