using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.Core.Utilities.Interceptors;
using ReCapProject.Data.Access.Abstract;
using ReCapProject.Data.Access.EntityFramework;
using ReCapProject.Data.Access.EntityFramework.Repositories;
using System;

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

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}