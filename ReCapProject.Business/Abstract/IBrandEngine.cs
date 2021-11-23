using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Abstract
{
    public interface IBrandEngine : IBusinessEngine
    {
        IDataResult<Brand> GetById(int id);
        IDataResult<Brand> GetByExpression(Expression<Func<Brand, bool>> expression);
        IDataResult<ICollection<Brand>> GetAll(int skip, int take, Expression<Func<Brand, bool>> expression = null);
        IDataResult<Brand> Insert(Brand brand);
        IDataResult<Brand> Update(Brand brand);
        IResult Delete(Brand brand);
    }
}