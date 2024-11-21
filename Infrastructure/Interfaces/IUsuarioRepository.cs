using ProjetoMvc.Models;

namespace ProjetoMvc.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
     
    {
        Task<Usuario> Adicionar(Usuario usuario);


        // Obt�m todos os usu�rios
        Task<IEnumerable<Usuario>> ListarTodos();

        // Obt�m um usu�rio por ID
        Task<Usuario> ObterPorId(int id);

        // Atualiza um usu�rio existente
        Task<Usuario> Atualizar(Usuario usuario);

        // Remove um usu�rio pelo ID
        Task<bool> Deletar(int id);
    }
}
