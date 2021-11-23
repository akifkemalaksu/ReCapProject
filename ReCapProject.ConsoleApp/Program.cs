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

            ICustomerRepository customerRepository = new EFCustomerRepository(context);
            ICustomerEngine customerEngine = new CustomerEngine(customerRepository);

            IUserRepository userRepository = new EFUserRepository(context);
            IUserEngine userEngine = new UserEngine(userRepository);

            IRentalRepository rentalRepository = new EFRentalRepository(context);
            IRentalEngine rentalEngine = new RentalEngine(rentalRepository);


            var user1 = new User
            {
                FirstName = "Akif Kemal",
                LastName = "Aksu",
                Email = "akifkemalaksu@gmail.com",
                Password = "1997akifkemal"
            };
        }
    }
}
