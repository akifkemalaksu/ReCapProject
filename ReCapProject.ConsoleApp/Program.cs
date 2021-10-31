using ReCapProject.Business;
using ReCapProject.Business.Abstracts;
using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Access.EntityFramework;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using ReCapProject.Data.Entities;
using System;

namespace ReCapProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var car1 = new Car()
            //{
            //    brand = new Brand()
            //    {
            //        Name = "Audi A4"
            //    },
            //    color = new Color()
            //    {
            //        Name = "Siyah"
            //    },
            //    ModelYear = 2000,
            //    DailyPrice = 100,
            //    Description = "Manuel 1.6"
            //};

            //var car2 = new Car()
            //{
            //    brand = new Brand()
            //    {
            //        Name = "Honda Accord"
            //    },
            //    color = new Color()
            //    {
            //        Name = "Füme"
            //    },
            //    ModelYear = 2004,
            //    DailyPrice = 150,
            //    Description = "Otomatik 2.4"
            //};


            ReCapContext context = new ReCapContext();
            ICarRepository carRepository = new CarRepository(context);
            IColorRepository colorRepository = new ColorRepository(context);
            ICarEngine carEngine = new CarEngine(carRepository);
            IColorEngine colorEngine = new ColorEngine(colorRepository);

            foreach (var item in carEngine.GetCarsByColor(colorEngine.GetColorById(1), 0, 100))
            {
                Console.WriteLine(item.brand.Name);
            }
        }
    }
}
