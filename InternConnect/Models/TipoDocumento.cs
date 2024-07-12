using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class TipoDocumento
    {
        [Key]
        public int TipoDocumentoId { get; set; }  // Example property

        public string? NombreTipoDocumento { get; set; }  // Example property
    }
}
