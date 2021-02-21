using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        //WebAPI startup'taki işlemler burada yapılıyor
        protected override void Load(ContainerBuilder builder)
        {
            //WebAPI startuptaki services.AddSingleton<ICarService,CarManager>(); ile aynı işlemi yapar
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();//ICarService istendiğinde CarManager oluştur
            builder.RegisterType<EFCarDAL>().As<ICarDAL>().SingleInstance();//services.AddSingleton<ICarDAL, EFCarDAL>();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EFBrandDAL>().As<IBrandDAL>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EFColorDAL>().As<IColorDAL>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EFCustomerDAL>().As<ICustomerDAL>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EFRentalDAL>().As<IRentalDAL>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EFUserDAL>().As<IUserDAL>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
