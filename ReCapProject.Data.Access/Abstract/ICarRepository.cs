using ReCapProject.Core.Data.Access;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System.Collections.Generic;

namespace ReCapProject.Data.Access.Abstract
{
    public interface ICarRepository : IRepository<Car, int>
    {
        public List<CarDTO> GetAllCarsDetails();
    }
}