using AutoMapper;
using Empleados.Core.IServices;
using Empleados.Domain.IRepository;

namespace Empleados.Core.Services
{
    public class CargoService : Service<Domain.Entities.Cargo, Dtos.Cargo>, ICargoService
    {
        public CargoService(ICargoRepository cargoRepository, IMapper mapper)
            : base(cargoRepository, mapper)
        {
        }
    }
}
