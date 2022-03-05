﻿using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Abstract
{
    public interface ICarEngine : IBusinessEngine
    {
        IDataResult<Car> GetById(int id);

        IDataResult<Car> GetByExpression(Expression<Func<Car, bool>> expression);

        IDataResult<ICollection<Car>> GetAll(Expression<Func<Car, bool>> expression = null);

        IDataResult<ICollection<CarDto>> GetAllWithDetails(int? brandId, int? colorId);
        IDataResult<CarDto> GetWithDetails(int id);

        IDataResult<Car> Insert(Car car);

        IDataResult<Car> Update(Car car);

        IResult Delete(Car car);

        IResult Delete(int id);
    }
}