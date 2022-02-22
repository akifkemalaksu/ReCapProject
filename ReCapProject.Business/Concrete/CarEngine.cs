using ReCapProject.Business.Abstract;
using ReCapProject.Business.BusinessAspects.Autofac;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Caching;
using ReCapProject.Core.Aspects.Autofac.Transaction;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
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

        [CacheRemoveAspect("ICarEngine.Get")]
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

        [SecuredOperation("Car.List")]
        [CacheAspect]
        public IDataResult<ICollection<Car>> GetAll(Expression<Func<Car, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Car>>(_carRepository.GetList(expression));
        }

        public IDataResult<ICollection<CarDto>> GetAllWithDetails()
        {
            return new SuccessDataResult<ICollection<CarDto>>(_carRepository.GetAllCarsDetails());
        }

        [CacheAspect]
        public IDataResult<Car> GetByExpression(Expression<Func<Car, bool>> expression)
        {
            return new SuccessDataResult<Car>(_carRepository.Get(expression));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carRepository.Get(id));
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarEngine.Get")]
        [TransactionScopeAspect]
        public IDataResult<Car> Insert(Car car)
        {
            car = _carRepository.Add(car);
            _carRepository.SaveChanges();
            return new SuccessDataResult<Car>(car);
        }

        [CacheRemoveAspect("ICarEngine.Get")]
        public IDataResult<Car> Update(Car car)
        {
            car = _carRepository.Update(car);
            _carRepository.SaveChanges();
            return new SuccessDataResult<Car>(car);
        }
    }
}