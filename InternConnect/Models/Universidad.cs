using System.ComponentModel.DataAnnotations;

namespace InternConnect.Models
{
    public class Universidad
    {
        [Key]
        public int IDUniversidad { get; set; }  // Example property for primary key

        public string Nombre { get; set; }  // Example property for university name


    }
}
