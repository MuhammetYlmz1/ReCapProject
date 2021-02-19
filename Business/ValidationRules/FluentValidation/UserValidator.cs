﻿using Entities.Concrete;
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
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.FirsName).NotEmpty().WithMessage("Lütfen İsminizi giriniz");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Lütfen Soyisminizi giriniz");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola kısmını boş geçemezsiniz");
            
        }
    }
}
