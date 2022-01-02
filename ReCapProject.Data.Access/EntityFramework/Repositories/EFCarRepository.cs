using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFCarRepository : EFRepositoryBase<EFReCapContext, Car, int>, ICarRepository
    {
        public EFCarRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }

        public List<CarDTO> GetAllCarsDetails()
        {
            return (from car in _dbSet
                    join brand in _dbContext.Brands on car.BrandId equals brand.Id
                    join color in _dbContext.Colors on car.ColorId equals color.Id
                    select new CarDTO
                    {
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice
                    }).ToList();
        }
    }
}
