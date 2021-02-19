using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(2021).WithMessage("Araba Modeli 2021 e eşit veya küçük olmalı");
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.Description).MaximumLength(100);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Kiralama ücreti 0 dan büyük olamalı");
        }

    }
}
