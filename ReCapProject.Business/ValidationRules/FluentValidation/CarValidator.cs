using FluentValidation;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.brandId).NotEmpty();
            RuleFor(x => x.colorId).NotEmpty();
            RuleFor(x => x.ModelYear).NotEmpty();
            RuleFor(x => x.DailyPrice).NotEmpty();
            RuleFor(x => x.ModelYear).GreaterThan(1990);
            RuleFor(x => x.DailyPrice).GreaterThan(0);
        }
    }
}