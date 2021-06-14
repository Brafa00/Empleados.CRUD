using Empleados.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Empleados.Core.Extensions
{
    public static class ServiceProvider
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.Load("Empleados.Core"));

            //Surenting.dbo
            services.AddDbContext<EmpleadosContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("EmpleadosDatabase"));
            }, ServiceLifetime.Transient);
        }
    }
}
