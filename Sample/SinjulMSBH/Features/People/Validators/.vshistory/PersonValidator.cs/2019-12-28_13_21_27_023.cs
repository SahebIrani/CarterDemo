using FluentValidation;

namespace Sample.SinjulMSBH.Features.People.Validators.vshistory.PersonValidator.cs
{
	public class PersonValidator : AbstractValidator<Person>
	{
		public PersonValidator() => RuleFor(p => p.Name).NotEmpty();
	}
}
