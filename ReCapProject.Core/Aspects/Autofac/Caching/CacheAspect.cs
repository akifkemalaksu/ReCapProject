using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ReCapProject.Core.CrossCuttingConcerns.Caching;
using ReCapProject.Core.Utilities.Interceptors;
using ReCapProject.Core.Utilities.IoC;
using System;
using System.Linq;

namespace ReCapProject.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterceptionAttribute
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}