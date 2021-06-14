using System.ComponentModel.DataAnnotations;

namespace Empleados.Core.Dtos
{
    public class Empleado
    {
        public int? Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }
        
        [Required]
        public string Documento { get; set; }
        
        [Required]
        public int IdCargo { get; set; }
        
        public virtual Cargo Cargo { get; set; }
    }
}
