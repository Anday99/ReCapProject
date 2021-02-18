using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.CompanyName).NotEmpty();
            RuleFor(customer => customer.CompanyName).MinimumLength(2);
            RuleFor(customer => customer.CompanyName).MaximumLength(50);
            RuleFor(customer => customer.UserId).NotEmpty();
        }
    }
}
