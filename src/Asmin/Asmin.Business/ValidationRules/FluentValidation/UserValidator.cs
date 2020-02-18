using Asmin.Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty();

            RuleFor(user => user.LastName)
                .NotEmpty();

            RuleFor(user => user.Email)
                .EmailAddress();

            RuleFor(user => user.Password)
                .NotEmpty();
        }
    }
}
