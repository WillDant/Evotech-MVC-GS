using ProjetoMvc.Infrastructure.Interfaces;
using ProjetoMvc.Models;

namespace ProjetoMvc.Services
{
    public class DispositivoService
    {
        private readonly IDispositivoRepository _dispositivoRepository;

        public DispositivoService(IDispositivoRepository dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        public async Task<Dispositivo> AdicionarDispositivo(Dispositivo dispositivo)
        {
            // Regra de negócio para validação pode ser adicionada aqui
            return await _dispositivoRepository.AdicionarDispositivo(dispositivo);
        }

        public async Task<IEnumerable<Dispositivo>> ListarTodosDispositivos()
        {
            return await _dispositivoRepository.ListarTodosDispositivos();
        }

        public async Task<Dispositivo> ObterDispositivoPorId(int id)
        {
            return await _dispositivoRepository.ObterDispositivoPorId(id);
        }

        public async Task<Dispositivo> AtualizarDispositivo(Dispositivo dispositivo)
        {
            return await _dispositivoRepository.AtualizarDispositivo(dispositivo);
        }
        public async Task<bool> DeletarDispositivo(int id)
        {
            return await _dispositivoRepository.DeletarDispositivo(id);
        }
    }
}
