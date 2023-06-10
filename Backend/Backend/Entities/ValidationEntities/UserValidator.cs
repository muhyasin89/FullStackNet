using Backend.Entities;
using FluentValidation;

namespace Backend.Entities.ValidationEntities
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(0, 100);
            RuleFor(x => x.Email).EmailAddress();

        }
    }
}
