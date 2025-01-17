﻿using Castle.DynamicProxy;
using Core.Aspect.Autofac.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {//Otomatik olarak bütün logları kapsayan b,r çalışma
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new PerformanceAspect(10));
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
