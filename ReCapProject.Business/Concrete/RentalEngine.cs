﻿using ReCapProject.Business.Abstract;
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
    public class RentalEngine : IRentalEngine
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalEngine(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public IResult Delete(Rental rental)
        {
            _rentalRepository.Delete(rental);
            _rentalRepository.SaveChanges();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var rental = GetById(id);
            if (rental.Data is not null)
            {
                Delete(rental.Data);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.NotFound);
            }
        }

        public IDataResult<ICollection<Rental>> GetAll(int skip, int take, Expression<Func<Rental, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Rental>>(_rentalRepository.GetList(skip, take, expression));
        }

        public IDataResult<Rental> GetByExpression(Expression<Func<Rental, bool>> expression)
        {
            return new SuccessDataResult<Rental>(_rentalRepository.Get(expression));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalRepository.Get(id));
        }

        [ValidationAspectAttribute(typeof(RentalValidator))]
        public IDataResult<Rental> Insert(Rental rental)
        {
            var carIsRented = _rentalRepository
                                .Get(x => x.CarId == rental.CarId &&
                                        (x.ReturnDate == null || x.ReturnDate >= DateTime.Now));
            if (carIsRented is null)
            {
                rental = _rentalRepository.Add(rental);
                _rentalRepository.SaveChanges();
                return new SuccessDataResult<Rental>(rental);
            }
            else
            {
                return new ErrorDataResult<Rental>(Messages.CarIsRented);
            }
        }

        public IDataResult<Rental> Update(Rental rental)
        {
            rental = _rentalRepository.Update(rental);
            _rentalRepository.SaveChanges();
            return new SuccessDataResult<Rental>(rental);
        }
    }
}