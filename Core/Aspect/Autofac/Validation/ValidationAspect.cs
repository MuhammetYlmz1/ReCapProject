using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//bana validator type ver
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir Doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//ilk base type ını bul daha sonra generik argümanlarında ilkini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//metodun parametrelerine bak entity type denk gelen validator ün tipine eşit olan parametreleri git bul 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
