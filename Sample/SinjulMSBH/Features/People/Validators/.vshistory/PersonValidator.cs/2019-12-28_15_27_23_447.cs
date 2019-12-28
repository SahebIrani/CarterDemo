using FluentValidation;

using Sample.SinjulMSBH.Domain;

namespace Sample.SinjulMSBH.Features.People.Validators
{
	public class PersonValidator : AbstractValidator<Person>
	{
		public PersonValidator()
		{
			RuleFor(p => p.Name).NotEmpty();
			RuleFor(x => x.Age).GreaterThan(0);
		}
	}
}
