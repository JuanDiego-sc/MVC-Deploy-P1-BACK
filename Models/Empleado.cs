using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace MiniCoreEnriqueMerizalde.Models
{
    public class Empleado
    {

        [System.ComponentModel.DataAnnotations.Key]
        public int Id_Empleado { get; set; }

        [Required]
        public string Nombre_Empleado { get; set; }

        [Required]

        public string Apellido_Empleado { get; set; }
    }
}