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

        // Adicionar um novo usuário
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            return await _usuarioRepository.Adicionar(usuario);
        }

        // Listar todos os usuários
        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            return await _usuarioRepository.ListarTodos();
        }

        // Obter um usuário por ID
        public async Task<Usuario> ObterPorId(int id)
        {
            return await _usuarioRepository.ObterPorId(id);
        }

        // Atualizar um usuário existente
        public async Task<bool> Atualizar(Usuario usuario)
        {
            var usuarioExistente = await _usuarioRepository.ObterPorId(usuario.Id);

            if (usuarioExistente == null)
            {
                return false; // Usuário não encontrado
            }

            // Atualiza os campos relevantes
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Senha = usuario.Senha;

            await _usuarioRepository.Atualizar(usuarioExistente);
            return true;
        }


        // Deletar um usuário pelo ID
        public async Task<bool> Deletar(int id)
        {
            return await _usuarioRepository.Deletar(id);
        }
    }
}
