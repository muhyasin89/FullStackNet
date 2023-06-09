using Backend.Data.Model;
using FluentValidation;

namespace Backend.Data.ValidationModel
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
