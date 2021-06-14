using AutoMapper;
using Empleados.Core.IServices;
using Empleados.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Core.Services
{
    public class EmpleadoService: Service<Domain.Entities.Empleado, Dtos.Empleado>, IEmpleadoService
    {
        public EmpleadoService(IEmpleadoRepository empleadoRepository, IMapper mapper)
            : base(empleadoRepository, mapper) 
        {
        }


        public async Task EliminarEmpleadoAsync(int idEmpleado)
        {
            var empleado = (await GetAllAsync(x => x.Id == idEmpleado).ConfigureAwait(false))?.FirstOrDefault();

            if (empleado is null)
            {
                throw new KeyNotFoundException($"No se encontró un Empleado con Id {idEmpleado} en la base de datos");
            }

            await DeleteAsync(empleado).ConfigureAwait(false);
        }
    }
}
