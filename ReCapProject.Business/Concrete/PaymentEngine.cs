using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Concrete
{
    public class PaymentEngine : IPaymentEngine
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentRentalMapRepository _paymentRentalMapRepository;

        public PaymentEngine(IPaymentRepository paymentRepository, IPaymentRentalMapRepository paymentRentalMapRepository)
        {
            _paymentRepository = paymentRepository;
            _paymentRentalMapRepository = paymentRentalMapRepository;
        }

        public IResult Delete(Payment payment)
        {
            var maps = _paymentRentalMapRepository.GetList(x => x.PaymentId == payment.Id) as List<PaymentRentalMap>;
            maps.ForEach(map => DeleteMap(map));

            _paymentRepository.Delete(payment);
            _paymentRepository.SaveChanges();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var payment = _paymentRepository.Get(id);
            if (payment == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return Delete(payment);
        }

        public IResult DeleteMap(PaymentRentalMap map)
        {
            _paymentRentalMapRepository.Delete(map);
            return new SuccessResult();
        }

        public IDataResult<ICollection<Payment>> GetAll(Expression<Func<Payment, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Payment>>(
                _paymentRepository.GetList(expression)
                );
        }

        public IDataResult<Payment> GetByExpression(Expression<Func<Payment, bool>> expression)
        {
            return new SuccessDataResult<Payment>(
                _paymentRepository.Get(expression)
                );
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(
                _paymentRepository.Get(id)
                );
        }

        public IDataResult<ICollection<PaymentRentalMap>> GetMaps(Expression<Func<PaymentRentalMap, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<PaymentRentalMap>>(
                _paymentRentalMapRepository.GetList(expression)
                );
        }

        public IDataResult<Payment> Insert(Payment payment)
        {
            _paymentRepository.Add(payment);
            _paymentRepository.SaveChanges();
            return new SuccessDataResult<Payment>(payment);
        }

        public IDataResult<PaymentRentalMap> InsertMap(PaymentRentalMap map)
        {
            _paymentRentalMapRepository.Add(map);
            _paymentRentalMapRepository.SaveChanges();
            return new SuccessDataResult<PaymentRentalMap>(map);
        }

        public IDataResult<Payment> Update(Payment payment)
        {
            _paymentRepository.Update(payment);
            _paymentRepository.SaveChanges();
            return new SuccessDataResult<Payment>(payment);
        }
    }
}