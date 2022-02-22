using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Concrete
{
    public class UserEngine : IUserEngine
    {
        private readonly IUserRepository _userRepository;

        public UserEngine(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult Delete(User user)
        {
            _userRepository.Delete(user);
            _userRepository.SaveChanges();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var user = GetById(id);
            if (user.Data is not null)
            {
                Delete(user.Data);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.NotFound);
            }
        }

        public IDataResult<ICollection<User>> GetAll(Expression<Func<User, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<User>>(_userRepository.GetList(expression));
        }

        public IDataResult<User> GetByExpression(Expression<Func<User, bool>> expression)
        {
            return new SuccessDataResult<User>(_userRepository.Get(expression));
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userRepository.Get(id));
        }

        public IDataResult<ICollection<OperationClaim>> GetOperationClaims(User user)
        {
            return new SuccessDataResult<ICollection<OperationClaim>>(_userRepository.GetOperationClaims(user));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<User> Insert(User user)
        {
            user = _userRepository.Add(user);
            _userRepository.SaveChanges();
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Update(User user)
        {
            user = _userRepository.Update(user);
            _userRepository.SaveChanges();
            return new SuccessDataResult<User>(user);
        }
    }
}