using Empleados.Core.Dtos;
using Empleados.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService cargoService;

        public CargoController(ICargoService cargoService)
        {
            this.cargoService = cargoService;
        }


        [HttpGet("GetAllCargos")]
        [Produces(typeof(IList<Cargo>))]
        public async Task<IActionResult> GetAllCargosAsync()
        {
            return Ok(await cargoService.GetAllAsync().ConfigureAwait(false));
        }

    }
}
