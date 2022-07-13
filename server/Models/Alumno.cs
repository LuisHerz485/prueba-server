using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Alumno
    {
       public int Id { get; set; }

        [Required]
       public string apellidos { get; set; }

        [Required]
        public string nombres { get; set; }

        [Required]
        public string dni { get; set; }
    }
}
