using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Beneficios
    {
        [Key]
        public int IDBeneficios {  get; set; }
        public string? TipoBeneficios { get; set; }
        public string? Descripcion { get; set; }
    }
}
