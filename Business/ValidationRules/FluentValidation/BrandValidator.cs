using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.BrandName).NotEmpty();
            RuleFor(brand => brand.BrandName).MinimumLength(2);
        }
    }
}
