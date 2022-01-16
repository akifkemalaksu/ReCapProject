using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace ReCapProject.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var test = type.GetMethod(method.Name);
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); // Loglama için, henüz hazır değil.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}