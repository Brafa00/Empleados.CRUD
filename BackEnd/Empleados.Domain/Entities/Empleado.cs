using System;
using System.Collections.Generic;
using System.Text;

namespace Empleados.Domain.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public int IdCargo { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
