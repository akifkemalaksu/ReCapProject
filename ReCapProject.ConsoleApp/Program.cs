using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;

namespace ReCapProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EFReCapContext context = new EFReCapContext();

            // Car
            ICarRepository carRepository = new EFCarRepository(context);
            ICarEngine carEngine = new CarEngine(carRepository);

            // Brand
            IBrandRepository brandRepository = new EFBrandRepository(context);
            IBrandEngine brandEngine = new BrandEngine(brandRepository);

            // Color
            IColorRepository colorRepository = new EFColorRepository(context);
            IColorEngine colorEngine = new ColorEngine(colorRepository);


            //ColorAndBrandMultiInsertTest(brandEngine, colorEngine);
            //CarInsertTest(carEngine, brandEngine, colorEngine);
            //GetAllTest(brandEngine, colorEngine);
            //DeleteTest(brandEngine);

            foreach (var details in carEngine.GetAllCarsDetails())
            {
                Console.WriteLine($@"
                    Marka: {details.BrandName}
                    Renk: {details.ColorName}
                    Açıklama: {details.Description}
                    Model: {details.ModelYear}
                    Günlük Fiyat: {details.DailyPrice}
                ");
            }
        }

        private static void DeleteTest(IBrandEngine brandEngine)
        {
            var brand = brandEngine.GetByExpression(x => x.Name.Contains("volks"));
            if (brand is not null)
            {
                brandEngine.Delete(brand);
            }
        }

        private static void GetAllTest(IBrandEngine brandEngine, IColorEngine colorEngine)
        {
            foreach (var brand in brandEngine.GetAll(0, 10))
            {
                Console.WriteLine(brand.Name);
            }
            foreach (var color in colorEngine.GetAll(0, 10))
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void CarInsertTest(ICarEngine carEngine, IBrandEngine brandEngine, IColorEngine colorEngine)
        {
            var brand = brandEngine.GetByExpression(x => x.Name == "Audi");
            if (brand is null)
            {
                brand = new Brand { Name = "Audi" };
                brand = brandEngine.Insert(brand);
            }
            var color = colorEngine.GetByExpression(x => x.Name == "Siyah");
            if (color is null)
            {
                color = new Color { Name = "Siyah" };
                color = colorEngine.Insert(color);
            }

            Car car = new Car { brandId = brand.Id, colorId = color.Id, ModelYear = 2000, DailyPrice = 100, Description = "A4 B5" };
            carEngine.Insert(car);
        }

        private static void ColorAndBrandMultiInsertTest(IBrandEngine brandEngine, IColorEngine colorEngine)
        {
            List<Brand> brands = new List<Brand>{
                new Brand() { Name = "Audi" },
                new Brand() { Name = "Honda" },
                new Brand() { Name = "BMW" },
                new Brand() { Name = "Mercedes" },
                new Brand() { Name = "Volkwagen" },
            };


            List<Color> colors = new List<Color> {
                new Color{ Name = "Siyah" },
                new Color{ Name = "Beyaz" },
                new Color{ Name = "Kırmızı" },
                new Color{ Name = "Lacivert" },
                new Color{ Name = "Gri" },
                new Color{ Name = "Turuncu" },
            };

            brandEngine.InsertAll(brands);
            colorEngine.InsertAll(colors);
        }
    }
}
