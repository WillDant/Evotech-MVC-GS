using Microsoft.EntityFrameworkCore;
using ProjetoMvc.Infrastructure.Interfaces;
using ProjetoMvc.Models;
using ProjetoMvc.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoMvc.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Adicionar um novo usuário
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            _context.T_Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // Listar todos os usuários
        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            return await _context.T_Usuario.ToListAsync();
        }

        // Obter um usuário por ID
        public async Task<Usuario> ObterPorId(int id)
        {
            return await _context.T_Usuario.FindAsync(id);
        }

        // Atualizar um usuário existente
        public async Task<Usuario> Atualizar(Usuario usuario)
        {
            var usuarioExistente = await _context.T_Usuario.FindAsync(usuario.Id);

            if (usuarioExistente == null)
            {
                return null; // Pode lançar uma exceção personalizada, dependendo da lógica do negócio
            }

            _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();

            return usuarioExistente;
        }

        // Remover um usuário pelo ID
        public async Task<bool> Deletar(int id)
        {
            var usuario = await _context.T_Usuario.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.T_Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
