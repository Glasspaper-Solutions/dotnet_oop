using FluentValidation;

namespace BasicWebApi.Contracts.V1
{
    public class PersonUpdateModel
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
    public class PersonUpdateModelValidator : AbstractValidator<PersonUpdateModel>
    {
        public PersonUpdateModelValidator() 
        {
            RuleFor(x => x.Name)
                .Length(0, 14)
                .NotNull()
                .NotEmpty();
            
            RuleFor(x => x.Age)
                .InclusiveBetween(0, 100)
                .NotNull()
                .NotEmpty();
        }
    }
}