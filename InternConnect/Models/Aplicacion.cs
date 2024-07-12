using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Aplicacion
    {
        [Key]
        public int IDAplicacion { get; set; }
        public int IDEstudiante { get; set; }
        public int IDPasantia { get; set; }
        public string? EstadoAplicacion { get; set; }
        public DateTime? FechaAplicacion { get; set; }

    }

}
