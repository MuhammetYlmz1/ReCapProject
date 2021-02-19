using Castle.DynamicProxy;
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
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>//Git Classın Attributlerini oku
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)//Git Metodun Attributlerini oku daha sonra onları listeye koyacak
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            //Otomatik olarak sistemdeki bütün metodları loga dahil et (daha loglama altyapsını yapmadık)
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
