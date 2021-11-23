using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.Abstract
{
    public interface IUserEngine : IBusinessEngine
    {
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByExpression(Expression<Func<User, bool>> expression);
        IDataResult<ICollection<User>> GetAll(int skip, int take, Expression<Func<User, bool>> expression = null);
        IDataResult<User> Insert(User user);
        IDataResult<User> Update(User user);
        IResult Delete(User user);
    }
}
