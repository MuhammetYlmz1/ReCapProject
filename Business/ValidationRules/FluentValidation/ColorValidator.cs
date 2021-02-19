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
            RuleFor(clr => clr.Id).NotEmpty();
            RuleFor(clr => clr.Name).NotEmpty();
        }
    }
}
