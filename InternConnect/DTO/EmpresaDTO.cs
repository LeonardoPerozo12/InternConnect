using System.ComponentModel.DataAnnotations;

namespace InternConnect.DTO
{
    public class EmpresaDTO
    {
        public class RegistrarEmpresa
        {
            [Required]
            public string Nombre { get; set; }

            [Required]
            [EmailAddress]
            public string Correo { get; set; }

            public string Direccion { get; set; }

            public string RNC { get; set; }

            public string Descripcion { get; set; }

            // Se elimina la propiedad Verificacion del DTO

            // No se incluye LogoEmpresa ya que se maneja por separado en la subida de archivos

            [Required]
            public string ContraseñaHash { get; set; } // Usarás esta propiedad para la contraseña
        }

        public class LoginEmpresa
        {
            [Required]
            [EmailAddress]
            public string Correo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Contraseña { get; set; }
        }
    }
}
