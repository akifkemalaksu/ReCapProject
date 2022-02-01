using ReCapProject.Business.Abstract;
using ReCapProject.Business.BusinessAspects.Autofac;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Concrete
{
    public class CarEngine : ICarEngine
    {
        private readonly ICarRepository _carRepository;

        public CarEngine(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IResult Delete(Car car)
        {
            _carRepository.Delete(car);
            _carRepository.SaveChanges();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var car = GetById(id);
            if (car.Data is not null)
            {
                Delete(car.Data);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.NotFound);
            }
        }

        [SecuredOperationAttribute("Car.List")]
        public IDataResult<ICollection<Car>> GetAll(int skip, int take, Expression<Func<Car, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Car>>(_carRepository.GetList(skip, take, expression));
        }

        public IDataResult<Car> GetByExpression(Expression<Func<Car, bool>> expression)
        {
            return new SuccessDataResult<Car>(_carRepository.Get(expression));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carRepository.Get(id));
        }

        [ValidationAspectAttribute(typeof(CarValidator))]
        public IDataResult<Car> Insert(Car car)
        {
            car = _carRepository.Add(car);
            _carRepository.SaveChanges();
            return new SuccessDataResult<Car>(car);
        }

        public IDataResult<Car> Update(Car car)
        {
            car = _carRepository.Update(car);
            _carRepository.SaveChanges();
            return new SuccessDataResult<Car>(car);
        }
    }
}