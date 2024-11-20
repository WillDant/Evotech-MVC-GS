using System.ComponentModel.DataAnnotations;

namespace ProjetoMvc.Models
{
    public class Dispositivo
    {
        [Key]
        public int id_dispositivo { get; set; }
        [Required]
        public string nm_dispositivo { get; set; }
        [Required]
        public float potencia { get; set; }
    }
}
