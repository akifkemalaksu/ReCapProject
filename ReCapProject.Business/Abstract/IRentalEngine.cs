using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using ReCapProject.Data.Entities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Abstract
{
    public interface IRentalEngine : IBusinessEngine
    {
        IDataResult<Rental> GetById(int id);

        IDataResult<Rental> GetByExpression(Expression<Func<Rental, bool>> expression);

        IDataResult<ICollection<RentalDto>> GetWithDetails();

        IDataResult<ICollection<Rental>> GetAll(Expression<Func<Rental, bool>> expression = null);

        IDataResult<Rental> Insert(Rental rental);

        IDataResult<Rental> InsertWithPayment(RentalResponseModel rentalResponseModel);

        IDataResult<Rental> Update(Rental rental);

        IResult Delete(Rental rental);

        IResult Delete(int id);
    }
}