using ProjetoMvc.Models;

namespace ProjetoMvc.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
     
    {
        Task<Usuario> Adicionar(Usuario usuario);


        // Obtém todos os usuários
        Task<IEnumerable<Usuario>> ListarTodos();

        // Obtém um usuário por ID
        Task<Usuario> ObterPorId(int id);

        // Atualiza um usuário existente
        Task<Usuario> Atualizar(Usuario usuario);

        // Remove um usuário pelo ID
        Task<bool> Deletar(int id);
    }
}
