using ReCapProject.Core.Business;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Abstract
{
    public interface IUserEngine : IBusinessEngine
    {
        IDataResult<User> GetById(int id);

        IDataResult<User> GetByExpression(Expression<Func<User, bool>> expression);

        IDataResult<ICollection<User>> GetAll(Expression<Func<User, bool>> expression = null);

        IDataResult<User> Insert(User user);

        IDataResult<User> Update(User user);

        IResult Delete(User user);

        IResult Delete(int id);

        IDataResult<ICollection<OperationClaim>> GetOperationClaims(User user);
    }
}