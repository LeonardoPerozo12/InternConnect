using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Rol
    {
        [Key]
        public int IDRol { get; set; }

        public string Nombre { get; set; }
    }
}
