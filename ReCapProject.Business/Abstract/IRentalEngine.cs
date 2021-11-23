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
    public interface IRentalEngine: IBusinessEngine
    {
        IDataResult<Rental> GetById(int id);
        IDataResult<Rental> GetByExpression(Expression<Func<Rental, bool>> expression);
        IDataResult<ICollection<Rental>> GetAll(int skip, int take, Expression<Func<Rental, bool>> expression = null);
        IDataResult<Rental> Insert(Rental rental);
        IDataResult<Rental> Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
