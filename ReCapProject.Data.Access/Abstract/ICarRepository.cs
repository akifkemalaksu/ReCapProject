using ReCapProject.Core.DataAccess;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Data.Access.Abstract
{
    public interface ICarRepository : IRepository<Car, int>
    {
        public ICollection<CarDto> GetAllCarsDetailsWithCarFilter(Expression<Func<Car, bool>> expression = null);

        public CarDto GetWithDetails(Expression<Func<Car, bool>> expression);
    }
}