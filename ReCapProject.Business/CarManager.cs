using ReCapProject.Business.Abstracts;
using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business
{
    public class CarManager : ICarService
    {
        private readonly ICarDAL _carDAL;

        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public void Add(Car car)
        {
            _carDAL.Add(car);
        }

        public Car GetCarById(int Id)
        {
            return _carDAL.GetById(Id);
        }

        public List<Car> GetCars()
        {
            return _carDAL.GetAll();
        }
    }
}
