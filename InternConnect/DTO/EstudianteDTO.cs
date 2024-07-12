using System.ComponentModel.DataAnnotations;

namespace InternConnect.DTO
{
    public class EstudianteDTO
    {
        public class RegistrarEstudiante { 
            [Required]
            public string? Nombre { get; set; }

            [Required]
            [EmailAddress]
            public string? Correo { get; set; }

            public int IDUniversidad { get; set; }
            public int IDCarrera { get; set; }
            public string? Direccion { get; set; }
            public string? Telefono { get; set; }
            public int? TipoDocumento { get; set; }
            public string? Documento { get; set; }

            [DataType(DataType.Password)]
            public string ContraseñaHash { get; set; }
        }
        public class LoginEstudiante
        { 
            [Required]
            public string Nombre { get; set; }
            [Required]
            [EmailAddress]
            public string? Correo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Contraseña { get; set; }


        }        
    }
}
