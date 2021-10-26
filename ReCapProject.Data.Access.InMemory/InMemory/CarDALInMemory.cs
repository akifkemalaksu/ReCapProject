using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.InMemory
{
    public class CarDALInMemory : ICarDAL
    {
        private readonly List<Car> _cars;

        public CarDALInMemory()
        {
            _cars = new List<Car>();
        }

        public void Add(Car car)
        {
            car.Id = _cars.Count > 0 ? _cars.Max(x => x.Id) + 1 : 1;
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Delete(car.Id);
        }

        public void Delete(int Id)
        {
            int index = _cars.FindIndex(x => x.Id == Id);
            if (index != -1)
                _cars.RemoveAt(index);
            else
                throw new Exception("Araç bulunamadı.");
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            return _cars.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Car car)
        {
            int index = _cars.FindIndex(x => x.Id == car.Id);
            if (index != -1)
                _cars[index] = car;
            else
                throw new Exception("Araç bulunamadı.");
        }
    }
}
