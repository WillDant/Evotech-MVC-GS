using ProjetoMvc.Models;


namespace ProjetoMvc.Infrastructure.Interfaces
{
    public interface IDispositivoRepository
    {
        // Adiciona um novo dispositivo
        Task<Dispositivo> AdicionarDispositivo(Dispositivo dispositivo);

        // Obtém todos os dispositivos
        Task<IEnumerable<Dispositivo>> ListarTodosDispositivos();

        // Obtém um dispositivo por ID
        Task<Dispositivo> ObterDispositivoPorId(int id);

        // Atualiza um dispositivo existente
        Task<Dispositivo> AtualizarDispositivo(Dispositivo dispositivo);

        // Remove um dispositivo pelo ID
        Task<bool> DeletarDispositivo(int id);
    }
}
