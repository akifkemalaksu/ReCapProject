using ReCapProject.Business.Abstract;
using ReCapProject.Core.Data.Access;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Concrete
{
    public class ColorEngine : IColorEngine
    {
        private readonly IColorRepository _colorRepository;

        public ColorEngine(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public IResult Delete(Color color)
        {
            _colorRepository.Delete(color);
            _colorRepository.SaveChanges();
            return new SuccessResult();
        }

        public IDataResult<ICollection<Color>> GetAll(int skip, int take, Expression<Func<Color, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Color>>(_colorRepository.GetList(skip, take, expression));
        }

        public IDataResult<Color> GetByExpression(Expression<Func<Color, bool>> expression)
        {
            return new SuccessDataResult<Color>(_colorRepository.Get(expression));
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorRepository.Get(id));
        }

        public IDataResult<Color> Insert(Color color)
        {
            color = _colorRepository.Add(color);
            _colorRepository.SaveChanges();
            return new SuccessDataResult<Color>(color);
        }

        public IDataResult<Color> Update(Color color)
        {
            color = _colorRepository.Update(color);
            _colorRepository.SaveChanges();
            return new SuccessDataResult<Color>(color);
        }
    }
}
