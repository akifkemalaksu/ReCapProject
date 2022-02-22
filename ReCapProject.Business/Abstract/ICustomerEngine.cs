using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Abstract
{
    public interface ICustomerEngine : IBusinessEngine
    {
        IDataResult<Customer> GetById(int id);

        IDataResult<Customer> GetByExpression(Expression<Func<Customer, bool>> expression);

        IDataResult<ICollection<Customer>> GetAll(Expression<Func<Customer, bool>> expression = null);

        IDataResult<Customer> Insert(Customer customer);

        IDataResult<Customer> Update(Customer customer);

        IResult Delete(Customer customer);

        IResult Delete(int id);
    }
}