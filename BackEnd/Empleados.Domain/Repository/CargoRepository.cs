using Empleados.Domain.Entities;
using Empleados.Domain.IRepository;

namespace Empleados.Domain.Repository
{
    public class CargoRepository: ERepository<Cargo>, ICargoRepository
    {
        public CargoRepository(IQueryableUnitOfWork queryableUnitOfWork): base(queryableUnitOfWork)
        {

        }
    }
}
