using Microsoft.EntityFrameworkCore;
using ProjetoMvc.Infrastructure.Interfaces;
using ProjetoMvc.Models;
using ProjetoMvc.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoMvc.Infrastructure.Repositories
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly ApplicationDbContext _context;

        public DispositivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Adicionar um novo dispositivo
        public async Task<Dispositivo> AdicionarDispositivo(Dispositivo dispositivo)
        {
            _context.T_Dispositivo.Add(dispositivo);
            await _context.SaveChangesAsync();
            return dispositivo;
        }

        // Listar todos os dispositivos
        public async Task<IEnumerable<Dispositivo>> ListarTodosDispositivos()
        {
            return await _context.T_Dispositivo.ToListAsync();
        }

        // Obter um dispositivo por ID
        public async Task<Dispositivo> ObterDispositivoPorId(int id)
        {
            return await _context.T_Dispositivo.FindAsync(id);
        }

        // Atualizar um dispositivo existente
        public async Task<Dispositivo> AtualizarDispositivo(Dispositivo dispositivo)
        {
            var dispositivoExistente = await _context.T_Dispositivo.FindAsync(dispositivo.id_dispositivo);

            if (dispositivoExistente == null)
            {
                return null; // Pode lançar uma exceção personalizada, dependendo da lógica do negócio
            }

            _context.Entry(dispositivoExistente).CurrentValues.SetValues(dispositivo);
            await _context.SaveChangesAsync();

            return dispositivoExistente;
        }

        // Remover um dispositivo pelo ID
        public async Task<bool> DeletarDispositivo(int id)
        {
            var dispositivo = await _context.T_Dispositivo.FindAsync(id);
            if (dispositivo == null)
            {
                return false;
            }

            _context.T_Dispositivo.Remove(dispositivo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
