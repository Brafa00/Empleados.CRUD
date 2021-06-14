using Autofac;
using Empleados.Core.IServices;
using Empleados.Core.Services;
using Empleados.Domain;
using Empleados.Domain.IRepository;
using Empleados.Domain.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empleados.Core.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void CreateDependencyInjection(this ContainerBuilder builder, IConfiguration configuration)
        {

            //Register DataBaseContext
            builder.RegisterType<EmpleadosContext>().As<IQueryableUnitOfWork>();
            RegisterRepositoryType(builder);
            RegisterServiceType(builder);
        }

        private static void RegisterServiceType(ContainerBuilder builder)
        {
            builder.RegisterType<EmpleadoService>().As<IEmpleadoService>();
            builder.RegisterType<CargoService>().As<ICargoService>();
        }

        private static void RegisterRepositoryType(ContainerBuilder builder)
        {
            builder.RegisterType<EmpleadoRepository>().As<IEmpleadoRepository>();
            builder.RegisterType<CargoRepository>().As<ICargoRepository>();
        }
    }
}
