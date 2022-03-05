using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFCarRepository : EFRepositoryBase<EFReCapContext, Car, int>, ICarRepository
    {
        public EFCarRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }

        public ICollection<CarDto> GetAllCarsDetailsWithCarFilter(Expression<Func<Car, bool>> expression = null)
        {
            return (from car in (expression == null ? _dbSet : _dbSet.Where(expression))
                    join brand in _dbContext.Brands on car.BrandId equals brand.Id
                    join color in _dbContext.Colors on car.ColorId equals color.Id
                    select new CarDto
                    {
                        CarId = car.Id,
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice
                    }).ToList();
        }

        public CarDto GetWithDetails(Expression<Func<Car, bool>> expression)
        {
            return (from car in (expression == null ? _dbSet : _dbSet.Where(expression))
                    join brand in _dbContext.Brands on car.BrandId equals brand.Id
                    join color in _dbContext.Colors on car.ColorId equals color.Id
                    select new CarDto
                    {
                        CarId = car.Id,
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice
                    }).FirstOrDefault();
        }
    }
}