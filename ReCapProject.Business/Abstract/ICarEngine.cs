using ReCapProject.Core.Business;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System.Collections.Generic;

namespace ReCapProject.Business.Abstract
{
    public interface ICarEngine : IBusinessEngine<Car, int>
    {
        public List<CarDTO> GetAllCarsDetails();
    }
}