using ReCapProject.Business;
using ReCapProject.Business.Abstracts;
using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Access.InMemory;
using ReCapProject.Data.Entities;
using System;

namespace ReCapProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car()
            {
                brand = new Brand()
                {
                    Name = "Audi A4"
                },
                color = new Color()
                {
                    Name = "Siyah"
                },
                ModelYear = 2000,
                DailyPrice = 100,
                Description = "Manuel 1.6"
            };

            var car2 = new Car()
            {
                brand = new Brand()
                {
                    Name = "Honda Accord"
                },
                color = new Color()
                {
                    Name = "Füme"
                },
                ModelYear = 2004,
                DailyPrice = 150,
                Description = "Otomatik 2.4"
            };

            ICarDAL carDAL = new CarDALInMemory();
            ICarService carService = new CarManager(carDAL);

            carService.Add(car1);
            carService.Add(car2);

            foreach (var car in carService.GetCars())
            {
                Console.WriteLine($"Araç adı: {car.brand.Name}");
                Console.WriteLine($"Araç model yılı: {car.ModelYear}");
                Console.WriteLine($"Araç günlük kiralama ücreti: {car.DailyPrice}");
                Console.WriteLine($"Araç rengi: {car.color.Name}");
                Console.WriteLine($"Araç açıklama: {car.Description}");
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
