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
    public class CustomerEngine : ICustomerEngine
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerEngine(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IResult Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
            _customerRepository.SaveChanges();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var color = GetById(id);
            if (color.Data is not null)
            {
                Delete(color.Data);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.NotFound);
            }
        }

        public IDataResult<ICollection<Customer>> GetAll(Expression<Func<Customer, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Customer>>(_customerRepository.GetList(expression));
        }

        public IDataResult<Customer> GetByExpression(Expression<Func<Customer, bool>> expression)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(expression));
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerRepository.Get(id));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<Customer> Insert(Customer customer)
        {
            customer = _customerRepository.Add(customer);
            _customerRepository.SaveChanges();
            return new SuccessDataResult<Customer>(customer);
        }

        public IDataResult<Customer> Update(Customer customer)
        {
            customer = _customerRepository.Update(customer);
            _customerRepository.SaveChanges();
            return new SuccessDataResult<Customer>(customer);
        }
    }
}