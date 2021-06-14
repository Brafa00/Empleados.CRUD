using Empleados.Core.Dtos;
using Empleados.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empleados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly IEmpleadoService empleadoService;
        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }


        [HttpGet("GetAllEmpleados")]
        [Produces(typeof(IList<Empleado>))]
        public async Task<IActionResult> GetAllEmpleadosAsync()
        {
            return Ok(await empleadoService.GetAllAsync(includeProperties: "Cargo").ConfigureAwait(false));
        }

        [HttpGet("GetEmpleadoByDocumento/{documento}")]
        [Produces(typeof(Empleado))]
        public async Task<IActionResult> GetEmpleadoByDocumentoAsync([FromRoute] string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                return BadRequest("No se envió un Id de empleado a consultar");
            }

            return Ok(await empleadoService.GetAllAsync(filter: empleado=> empleado.Documento.Equals(documento), includeProperties: "Cargo").ConfigureAwait(false));
        }

        [HttpPost("AddEmpleado")]
        public async Task<IActionResult> AddEmpleadoAsync([FromBody] Empleado empleado)
        {
            await empleadoService.AddAsync(empleado).ConfigureAwait(false);
            return Accepted();
        }

        [HttpPut("UpdateEmpleado")]
        public async Task<IActionResult> UpdateEmpleadoAsync([FromBody] Empleado empleado)
        {
            if (empleado.Id is null)
            {
                return BadRequest("El Id del Empleado no debe ser nulo");
            }

            await empleadoService.UpdateAsync(empleado).ConfigureAwait(false);
            return Accepted();
        }

        [HttpDelete("DeleteEmpleado/{idEmpleado}")]
        public async Task<IActionResult> DeleteEmpleadoAsync([FromRoute]int idEmpleado)
        {
            if (idEmpleado == 0)
            {
                return BadRequest("El Id de empleado no puede ser nulo");
            }

            await empleadoService.EliminarEmpleadoAsync(idEmpleado).ConfigureAwait(false);
            return Accepted();
        }
    }
}
