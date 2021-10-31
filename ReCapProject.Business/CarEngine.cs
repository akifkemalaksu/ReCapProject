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
    public class CarEngine : ICarEngine
    {
        private readonly ICarRepository _carRepository;

        public CarEngine(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Add(Car car)
        {
            _carRepository.Add(car);
            _carRepository.SaveChanges();
        }

        public void Delete(Car car)
        {
            _carRepository.Delete(car);
            _carRepository.SaveChanges();
        }

        public Car GetCarById(int Id)
        {
            return _carRepository.Get(Id);
        }

        public List<Car> GetCarsByBrand(Brand brand, int skip, int take)
        {
            return _carRepository.GetList(skip, take, x => x.brand.Id == brand.Id).ToList();
        }

        public List<Car> GetCarsByColor(Color color, int skip, int take)
        {
            return _carRepository.GetList(skip, take, x => x.color.Id == color.Id).ToList();
        }

        public List<Car> GetCarsByDailyPrice(decimal min, decimal max, int skip, int take)
        {
            return _carRepository.GetList(skip, take, x => x.DailyPrice >= min && x.DailyPrice <= max).ToList();
        }

        public List<Car> GetCarsByModelYear(int modelYear, int skip, int take)
        {
            return _carRepository.GetList(skip, take, x => x.ModelYear == modelYear).ToList();
        }

        public void Update(Car car)
        {
            _carRepository.Update(car);
        }
    }
}
