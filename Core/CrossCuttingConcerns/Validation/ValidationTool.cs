﻿using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validate, object entity)
        {
            var context = new ValidationContext<object>(entity);
            
            var result = validate.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
