using Autofac;
using AutoMapper;
using Kapital.Application.Automapper;
using Kapital.Application.Services.BookingServices;
using Kapital.Domain.Repositories;
using Kapital.Infrastructure.Repositories;


namespace Kapital.Application.IoC
{
    public class AutofacResolver:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookingRepository>().As<IBookingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ApartmentRepository>().As<IApartmentRepository>().InstancePerLifetimeScope();

            builder.RegisterType<BookingService>().As<IBookingService>().InstancePerLifetimeScope();

            //Mapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<Mapping>();
            }
             )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
