using Autofac;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFReCapContext>();

            builder.Register(c => new EFBrandRepository(c.Resolve<EFReCapContext>())).As<IBrandRepository>().SingleInstance();
            builder.Register(c => new EFCarRepository(c.Resolve<EFReCapContext>())).As<ICarRepository>().SingleInstance();
            builder.Register(c => new EFColorRepository(c.Resolve<EFReCapContext>())).As<IColorRepository>().SingleInstance();
            builder.Register(c => new EFCustomerRepository(c.Resolve<EFReCapContext>())).As<ICustomerRepository>().SingleInstance();
            builder.Register(c => new EFRentalRepository(c.Resolve<EFReCapContext>())).As<IRentalRepository>().SingleInstance();
            builder.Register(c => new EFUserRepository(c.Resolve<EFReCapContext>())).As<IUserRepository>().SingleInstance();

            builder.RegisterType<BrandEngine>().As<IBrandEngine>().SingleInstance();
            builder.RegisterType<CarEngine>().As<ICarEngine>().SingleInstance();
            builder.RegisterType<ColorEngine>().As<IColorEngine>().SingleInstance();
            builder.RegisterType<CustomerEngine>().As<ICustomerEngine>().SingleInstance();
            builder.RegisterType<RentalEngine>().As<IRentalEngine>().SingleInstance();
            builder.RegisterType<UserEngine>().As<IUserEngine>().SingleInstance();
        }
    }
}