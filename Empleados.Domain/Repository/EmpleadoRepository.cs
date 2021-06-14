using Empleados.Domain.Entities;
using Empleados.Domain.IRepository;

namespace Empleados.Domain.Repository
{
    public class EmpleadoRepository: ERepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(IQueryableUnitOfWork queryableUnitOfWork)
            : base(queryableUnitOfWork)
        {
        }
    }
}
