using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.FirstName).MinimumLength(2);
            RuleFor(user => user.LastName).NotEmpty();
            RuleFor(user => user.LastName).MinimumLength(2);
            RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.Password).MinimumLength(5);
            RuleFor(user => user.Password).MaximumLength(25);
            RuleFor(user => user.Password).Must(ContainCapitalLetter);
        }

        private bool ContainCapitalLetter(string arg)
        {
            foreach (var letter in arg)
            {
                if (letter>='A' && letter<='Z')
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }

            return false;
        }
    }
}
