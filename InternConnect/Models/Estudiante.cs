using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Estudiante
    {
        [Key]
        public int IDEstudiante { get; set; }

        public string? Nombre { get; set; }

        public string? Correo { get; set; }

        public int? IDUniversidad { get; set; } // Permite valores nulos

        public int? IDCarrera { get; set; } // Permite valores nulos

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public int? TipoDocumento { get; set; } // Permite valores nulos

        public string? Documento { get; set; }

        public string ContraseñaHash { get; set; }

        public int IDRol { get; set; } // Nueva propiedad para el rol
        public Rol Rol { get; set; } // Propiedad de navegación
    }
}
