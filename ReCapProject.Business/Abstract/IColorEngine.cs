using ReCapProject.Core.Business;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Abstract
{
    public interface IColorEngine : IBusinessEngine
    {
        IDataResult<Color> GetById(int id);
        IDataResult<Color> GetByExpression(Expression<Func<Color, bool>> expression);
        IDataResult<ICollection<Color>> GetAll(int skip, int take, Expression<Func<Color, bool>> expression = null);
        IDataResult<Color> Insert(Color color);
        IDataResult<Color> Update(Color color);
        IResult Delete(Color color);
        IResult Delete(int id);
    }
}