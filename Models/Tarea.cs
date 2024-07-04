using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MiniCoreEnriqueMerizalde.Models
{
    public class Tarea
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id_Tarea { get; set; }

        [ForeignKey("Empleado")]
        public int Id_EmpleadoV { get; set; }

        [ForeignKey("Proyecto")]
        public int Id_ProyectoV { get; set; }
        public string Descripcion_Tarea { get; set; }
        public DateTime Fecha_Inicio_Tarea { get; set; }
        public int Tiempo_Estimado_Tarea { get; set; }
        public string Estado_Tarea { get; set; }

        public Empleado Empleado { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
