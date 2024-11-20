using System.ComponentModel.DataAnnotations;

namespace ProjetoMvc.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Senha { get; set; }
    }
}
