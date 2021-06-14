using System.Threading.Tasks;

namespace Empleados.Core.IServices
{
    public interface IEmpleadoService: IService<Domain.Entities.Empleado, Dtos.Empleado>
    {
       Task EliminarEmpleadoAsync(int idEmpleado);
    }
}
