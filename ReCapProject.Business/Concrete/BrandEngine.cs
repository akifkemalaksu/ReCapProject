using ReCapProject.Business.Abstract;
using ReCapProject.Core.Data.Access;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Business.Concrete
{
    public class BrandEngine : IBrandEngine
    {
        private readonly IBrandRepository _brandRepository;

        public BrandEngine(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IResult Delete(Brand brand)
        {
            _brandRepository.Delete(brand);
            _brandRepository.SaveChanges();
            return new SuccessResult();
        }

        public IDataResult<ICollection<Brand>> GetAll(int skip, int take, Expression<Func<Brand, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<Brand>>(_brandRepository.GetList(skip, take, expression));
        }

        public IDataResult<Brand> GetByExpression(Expression<Func<Brand, bool>> expression)
        {
            return new SuccessDataResult<Brand>(_brandRepository.Get(expression));
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandRepository.Get(id));
        }

        public IDataResult<Brand> Insert(Brand brand)
        {
            brand = _brandRepository.Add(brand);
            _brandRepository.SaveChanges();
            return new SuccessDataResult<Brand>(brand);
        }

        public IDataResult<Brand> Update(Brand brand)
        {
            brand = _brandRepository.Update(brand);
            _brandRepository.SaveChanges();
            return new SuccessDataResult<Brand>(brand);
        }
    }
}
