using FluentValidation;
using ReCapProject.Core.Entities.Concrete;
using System;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(2);
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(2);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}