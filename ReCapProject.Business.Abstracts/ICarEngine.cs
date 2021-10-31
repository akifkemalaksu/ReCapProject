using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.Abstracts
{
    public interface ICarEngine
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        Car GetCarById(int Id);
        List<Car> GetCarsByBrand(Brand brand, int skip, int take);
        List<Car> GetCarsByColor(Color color, int skip, int take);
        List<Car> GetCarsByDailyPrice(decimal min, decimal max, int skip, int take);
        List<Car> GetCarsByModelYear(int modelYear, int skip, int take);
    }
}
