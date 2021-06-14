using AutoMapper;
using Empleados.Core.Services;
using Empleados.Domain.IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Core.Test
{
    [TestClass]
    public class EmpleadoServiceTest
    {
        public IEmpleadoRepository EmpleadoRepository { get; set; }
        public IMapper Mapper{ get; set; }
        public EmpleadoService EmpleadoService { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            EmpleadoRepository = Substitute.For<IEmpleadoRepository>();
            Mapper = new Mapper(new MapperConfiguration(config => config.AddProfile(new MappingProfile())));
            EmpleadoService = new EmpleadoService(EmpleadoRepository, Mapper);
        }

        [TestMethod]
        public async Task EliminarEmpleadoAsync_Exception()
        {
            EmpleadosEntities = null;
            EmpleadoRepository.GetAllAsync(x => x.Id == 2).Returns(EmpleadosEntities);
            var ex = await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () =>
            {
                await EmpleadoService.EliminarEmpleadoAsync(2).ConfigureAwait(false);
            }).ConfigureAwait(false);

            Assert.IsNotNull(ex.Message);
        }

        [TestMethod]
        public async Task EliminarEmpleadoAsync_Succes()
        {
            EmpleadoRepository.GetAllAsync(x => x.Id == 1).ReturnsForAnyArgs(EmpleadosEntities);
            await EmpleadoService.EliminarEmpleadoAsync(1).ConfigureAwait(false);
            await EmpleadoRepository.Received(1).DeleteAsync(Arg.Any<Domain.Entities.Empleado>()).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task GetAllEmpleadosAsync_Succes()
        {
            EmpleadoRepository.GetAllAsync().ReturnsForAnyArgs(EmpleadosEntities);
            var result = await EmpleadoService.GetAllAsync().ConfigureAwait(false);
            Assert.IsTrue(result.Any());
        }


        #region Objects

        private IList<Domain.Entities.Empleado> EmpleadosEntities { get; set; } = new List<Domain.Entities.Empleado>
        {
            new Domain.Entities.Empleado
            {
                Nombre = "usuario",
                Apellido = "test",
                Documento = "1234",
                Id = 1,
                IdCargo = 1
            }
        };

        #endregion
    }
}
