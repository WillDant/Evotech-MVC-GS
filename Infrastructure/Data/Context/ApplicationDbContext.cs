using Microsoft.EntityFrameworkCore;
using ProjetoMvc.Models; // Ajuste o namespace conforme necessário

namespace ProjetoMvc.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> T_Usuario { get; set; }
        public DbSet<Dispositivo> T_Dispositivo { get; set; }

    }
}
