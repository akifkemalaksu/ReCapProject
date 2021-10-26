using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.Abstracts
{
    public interface ICarService
    {
        void Add(Car car);
        Car GetCarById(int Id);
        List<Car> GetCars();
    }
}
