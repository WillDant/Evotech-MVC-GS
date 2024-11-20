using ProjetoMvc.Models;

namespace ProjetoMvc.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Adicionar(Usuario usuario);
    }
}
