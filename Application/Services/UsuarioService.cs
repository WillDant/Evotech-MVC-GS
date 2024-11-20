using ProjetoMvc.Infrastructure.Interfaces;
using ProjetoMvc.Models;

namespace ProjetoMvc.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            return await _usuarioRepository.Adicionar(usuario);
        }
    }
}
