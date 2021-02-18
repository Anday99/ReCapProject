using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(color => color.ColorName).NotEmpty();
            RuleFor(color => color.ColorName).MinimumLength(2);
        }
    }
}
