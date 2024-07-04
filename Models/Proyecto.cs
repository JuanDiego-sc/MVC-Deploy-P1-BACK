using MessagePack;

namespace MiniCoreEnriqueMerizalde.Models
{    public class Proyecto
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id_Proyecto { get; set; }
        public string Nombre_Proyecto { get; set; }
    }
}
