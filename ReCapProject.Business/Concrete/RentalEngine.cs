using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Transaction;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using ReCapProject.Data.Entities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Concrete
{
    public class RentalEngine : IRentalEngine
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IPaymentEngine _paymentEngine;

        public RentalEngine(IRentalRepository rentalRepository, IPaymentEngine paymentEngine)
        {
            _rentalRepository = rentalRepository;
            _paymentEngine = paymentEngine;
        }

        public IResult Delete(Rental rental)
        {
            var mapResult = _paymentEngine.GetMaps(map => map.RentalId == rental.Id);
            if (!mapResult.Success)
            {
                return mapResult;
            }
            (mapResult.Data as List<PaymentRentalMap>).ForEach(map => _paymentEngine.DeleteMap(map));

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

        public IDataResult<ICollection<Rental>> GetAll(Expression<Func<Rental, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Rental>>(_rentalRepository.GetList(expression));
        }

        public IDataResult<Rental> GetByExpression(Expression<Func<Rental, bool>> expression)
        {
            return new SuccessDataResult<Rental>(_rentalRepository.Get(expression));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalRepository.Get(id));
        }

        public IDataResult<ICollection<RentalDto>> GetWithDetails()
        {
            return new SuccessDataResult<ICollection<RentalDto>>(_rentalRepository.GetAllRentalsDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
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

        [TransactionScopeAspect]
        public IDataResult<Rental> InsertWithPayment(RentalResponseModel rentalResponseModel)
        {
            var payment = new Payment()
            {
                CardHolderName = rentalResponseModel.CardHolderName,
                CardNumber = rentalResponseModel.CardNumber,
                Cvc = rentalResponseModel.Cvc,
                ExpireMonth = rentalResponseModel.ExpireMonth,
                ExpireYear = rentalResponseModel.ExpireYear
            };

            var rental = new Rental()
            {
                CarId = rentalResponseModel.CarId,
                CustomerId = 0,
                RentDate = rentalResponseModel.FromDate,
                ReturnDate = rentalResponseModel.ToDate,
            };

            var paymentResult = _paymentEngine.Insert(payment);
            if (!paymentResult.Success)
            {
                return new ErrorDataResult<Rental>(message: paymentResult.Message);
            }
            var rentalResult = Insert(rental);

            if (!rentalResult.Success)
            {
                return rentalResult;
            }

            _paymentEngine.InsertMap(new PaymentRentalMap()
            {
                PaymentId = paymentResult.Data.Id,
                RentalId = rentalResult.Data.Id,
                Price = rentalResponseModel.Price
            });

            return rentalResult;
        }

        public IDataResult<Rental> Update(Rental rental)
        {
            rental = _rentalRepository.Update(rental);
            _rentalRepository.SaveChanges();
            return new SuccessDataResult<Rental>(rental);
        }
    }
}