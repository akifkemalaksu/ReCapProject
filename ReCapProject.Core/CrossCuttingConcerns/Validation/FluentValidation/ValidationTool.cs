using FluentValidation;

namespace ReCapProject.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate<T>(IValidator validator, T entity)
        {
            var context = new ValidationContext<T>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}