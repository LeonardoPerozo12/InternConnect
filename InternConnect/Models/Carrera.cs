using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Carrera
    {
        [Key]
        public int IDCarrera { get; set; }
        public string? Nombre { get; set; }

    }
}
