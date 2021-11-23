using ReCapProject.Business.Abstract;
using ReCapProject.Core.Data.Access;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
