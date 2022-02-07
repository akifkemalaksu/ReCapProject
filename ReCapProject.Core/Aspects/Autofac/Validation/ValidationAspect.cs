using Castle.DynamicProxy;
using FluentValidation;
using ReCapProject.Core.CrossCuttingConcerns.Validation.FluentValidation;
using ReCapProject.Core.Utilities.Interceptors;
using System;
using System.Linq;

namespace ReCapProject.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterceptionAttribute
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Wrong validation type.");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}