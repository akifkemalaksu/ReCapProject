using ReCapProject.Core.DataAccess;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System.Collections.Generic;

namespace ReCapProject.Data.Access.Abstract
{
    public interface ICarRepository : IRepository<Car, int>
    {
        public ICollection<CarDto> GetAllCarsDetails();
    }
}