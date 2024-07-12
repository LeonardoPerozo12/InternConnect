using System;
using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Estudiante
    {
        [Key]
        public int IDEstudiante { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public int IDUniversidad { get; set; }

        public int IDCarrera { get; set; }

        public byte[] FotoEstudiante { get; set; } // Tipo byte[] para almacenar longblob

        public DateTime FechaIngreso { get; set; }

        public byte[] CV { get; set; } // Tipo byte[] para almacenar longblob

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public int TipoDocumento { get; set; }

        public string Documento { get; set; }
    }
}
