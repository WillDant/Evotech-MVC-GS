using System.ComponentModel.DataAnnotations;

namespace ProjetoMvc.Application.DTOs
{
    public class DispositivoDto
    {
        public int id_dispositivo { get; set; }
        [Required(ErrorMessage = "O campo Nome do Dispositivo é obrigatório")]
        public string nm_dispositivo { get; set; }

        [Required(ErrorMessage = "O campo de potência do Dispositivo é obrigatório")]
        public float potencia { get; set; }

    }
}
