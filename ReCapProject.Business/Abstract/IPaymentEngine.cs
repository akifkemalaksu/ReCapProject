using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Abstract
{
    public interface IPaymentEngine : IBusinessEngine
    {
        IDataResult<Payment> GetById(int id);

        IDataResult<Payment> GetByExpression(Expression<Func<Payment, bool>> expression);

        IDataResult<ICollection<Payment>> GetAll(Expression<Func<Payment, bool>> expression = null);

        IDataResult<ICollection<PaymentRentalMap>> GetMaps(Expression<Func<PaymentRentalMap, bool>> expression = null);

        IDataResult<Payment> Insert(Payment payment);

        IDataResult<PaymentRentalMap> InsertMap(PaymentRentalMap map);

        IDataResult<Payment> Update(Payment payment);

        IResult Delete(Payment payment);

        IResult DeleteMap(PaymentRentalMap map);

        IResult Delete(int id);
    }
}