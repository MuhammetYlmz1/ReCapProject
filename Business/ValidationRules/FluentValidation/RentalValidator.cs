﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().WithMessage("CarId boş bırakılamaz");
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage("CustomerId boş bırakılamaz");
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty();
           
        }
    }
}
