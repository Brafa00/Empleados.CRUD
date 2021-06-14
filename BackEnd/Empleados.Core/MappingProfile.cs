using AutoMapper;

namespace Empleados.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dtos.Cargo, Domain.Entities.Cargo>().ReverseMap();
            CreateMap<Dtos.Empleado, Domain.Entities.Empleado>().ReverseMap();
        }

    }
}
