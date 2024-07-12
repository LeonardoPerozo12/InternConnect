using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternConnect.Models
{
    public class Estudiante
    {
        public int IDEstudiante { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        public int? IDUniversidad { get; set; }

        public int? IDCarrera { get; set; }

        public byte[] FotoEstudiante { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public byte[] CV { get; set; }

        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        public int? TipoDocumentoId { get; set; }

        public string Documento { get; set; }

        // Relaciones
        [ForeignKey("IDUniversidad")]
        public Universidad Universidad { get; set; }

        [ForeignKey("IDCarrera")]
        public Carrera Carrera { get; set; }

        [ForeignKey("TipoDocumentoId")]
        public TipoDocumento TipoDocumento { get; set; }
    }
}
