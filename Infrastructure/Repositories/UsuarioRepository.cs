using Microsoft.EntityFrameworkCore;
using ProjetoMvc.Infrastructure.Interfaces;
using ProjetoMvc.Models;
using ProjetoMvc.Infrastructure.Data.Context;

namespace ProjetoMvc.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            _context.T_Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
