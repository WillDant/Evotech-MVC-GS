using ProjetoMvc.Infrastructure.Interfaces;
using ProjetoMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoMvc.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Adicionar um novo usu�rio
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            return await _usuarioRepository.Adicionar(usuario);
        }

        // Listar todos os usu�rios
        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            return await _usuarioRepository.ListarTodos();
        }

        // Obter um usu�rio por ID
        public async Task<Usuario> ObterPorId(int id)
        {
            return await _usuarioRepository.ObterPorId(id);
        }

        // Atualizar um usu�rio existente
        public async Task<bool> Atualizar(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.ObterPorId(usuario.Id);

            if (usuarioExistente == null)
            {
                return false; // Usu�rio n�o encontrado
            }

            // Atualiza os campos relevantes
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Senha = usuario.Senha;

            await _usuarioRepository.Atualizar(usuarioExistente);
            return true;
        }


        // Deletar um usu�rio pelo ID
        public async Task<bool> Deletar(int id)
        {
            return await _usuarioRepository.Deletar(id);
        }
    }
}
