using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFRentalRepository : EFRepositoryBase<EFReCapContext, Rental, int>, IRentalRepository
    {
        public EFRentalRepository(EFReCapContext dbContext) : base(dbContext)
        {
        }

        public ICollection<RentalDto> GetAllRentalsDetails()
        {
            return (from rental in _dbSet
                    join car in _dbContext.Cars on rental.CarId equals car.Id
                    join brand in _dbContext.Brands on car.BrandId equals brand.Id
                    join color in _dbContext.Colors on car.ColorId equals color.Id
                    join customer in _dbContext.Customers on rental.CustomerId equals customer.Id
                    select new RentalDto()
                    {
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        RentDate = rental.RentDate.ToString("dd.MM.yyyy HH:mm"),
                        ReturnDate = rental.ReturnDate.HasValue ? rental.ReturnDate.Value.ToString("dd.MM.yyyy HH:mm") : null
                    }).ToList();
        }
    }
}