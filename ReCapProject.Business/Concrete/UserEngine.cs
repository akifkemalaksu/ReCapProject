using ReCapProject.Business.Abstract;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public IDataResult<ICollection<User>> GetAll(int skip, int take, Expression<Func<User, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<User>>(_userRepository.GetList(skip, take, expression));
        }

        public IDataResult<User> GetByExpression(Expression<Func<User, bool>> expression)
        {
            return new SuccessDataResult<User>(_userRepository.Get(expression));
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userRepository.Get(id));
        }

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
