using ReCapProject.Business.Abstract;
using ReCapProject.Core.Business;
using ReCapProject.Core.Data.Access;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using ReCapProject.Data.Entities;
using ReCapProject.Data.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ReCapProject.Business.Concrete
{
    public class CarEngine : BusinessEngineBase<Car, ICarRepository, int>, ICarEngine
    {
        public CarEngine(ICarRepository repository) : base(repository)
        {
        }

        public List<CarDTO> GetAllCarsDetails()
        {
            return _repository.GetAllCarsDetails();
        }
    }
}
