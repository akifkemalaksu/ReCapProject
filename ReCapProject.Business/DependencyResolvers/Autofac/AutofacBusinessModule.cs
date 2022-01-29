using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.Core.Utilities.Interceptors;
using ReCapProject.Core.Utilities.Security;
using ReCapProject.Core.Utilities.Security.JWT;
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
            builder.RegisterType<EFReCapContext>().As<DbContext>();

            builder.Register(c => new EFBrandRepository(c.Resolve<EFReCapContext>())).As<IBrandRepository>().SingleInstance();
            builder.Register(c => new EFCarRepository(c.Resolve<EFReCapContext>())).As<ICarRepository>().SingleInstance();
            builder.Register(c => new EFColorRepository(c.Resolve<EFReCapContext>())).As<IColorRepository>().SingleInstance();
            builder.Register(c => new EFCustomerRepository(c.Resolve<EFReCapContext>())).As<ICustomerRepository>().SingleInstance();
            builder.Register(c => new EFRentalRepository(c.Resolve<EFReCapContext>())).As<IRentalRepository>().SingleInstance();
            builder.Register(c => new EFUserRepository(c.Resolve<EFReCapContext>())).As<IUserRepository>().SingleInstance();
            builder.Register(c => new EFCarImageRepository(c.Resolve<EFReCapContext>())).As<ICarImageRepository>().SingleInstance();
            builder.Register(c => new EFOperationClaimRepository(c.Resolve<EFReCapContext>())).As<IOperationClaimRepository>().SingleInstance();
            builder.Register(c => new EFUserOperationClaimRepository(c.Resolve<EFReCapContext>())).As<IUserOperationClaimRepository>().SingleInstance();

            // Bu şekilde EntityFrameworkBase'deki entity tanımlamasını görmüyor, eksra olarak new lemek gerektiriyor.

            //builder.RegisterType<EFBrandRepository>().As<IBrandRepository>().SingleInstance();
            //builder.RegisterType<EFCarRepository>().As<ICarRepository>().SingleInstance();
            //builder.RegisterType<EFColorRepository>().As<IColorRepository>().SingleInstance();
            //builder.RegisterType<EFCustomerRepository>().As<ICustomerRepository>().SingleInstance();
            //builder.RegisterType<EFRentalRepository>().As<IRentalRepository>().SingleInstance();
            //builder.RegisterType<EFUserRepository>().As<IUserRepository>().SingleInstance();
            //builder.RegisterType<EFCarImageRepository>().As<ICarImageRepository>().SingleInstance();
            //builder.RegisterType<EFOperationClaimRepository>().As<IOperationClaimRepository>().SingleInstance();
            //builder.RegisterType<EFUserOperationClaimRepository>().As<IUserOperationClaimRepository>().SingleInstance();

            builder.RegisterType<BrandEngine>().As<IBrandEngine>().SingleInstance();
            builder.RegisterType<CarEngine>().As<ICarEngine>().SingleInstance();
            builder.RegisterType<ColorEngine>().As<IColorEngine>().SingleInstance();
            builder.RegisterType<CustomerEngine>().As<ICustomerEngine>().SingleInstance();
            builder.RegisterType<RentalEngine>().As<IRentalEngine>().SingleInstance();
            builder.RegisterType<UserEngine>().As<IUserEngine>().SingleInstance();
            builder.RegisterType<CarImageEngine>().As<ICarImageEngine>().SingleInstance();
            builder.RegisterType<AuthEngine>().As<IAuthEngine>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}