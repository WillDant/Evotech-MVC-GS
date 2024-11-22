using Microsoft.AspNetCore.Mvc;
using ProjetoMvc.Models;
using ProjetoMvc.Services;
using System.Threading.Tasks;

namespace ProjetoMvc.Controllers
{
    public class DispositivoController : Controller
    {
        private readonly DispositivoService _dispositivoService;

        public DispositivoController(DispositivoService dispositivoService)
        {
            _dispositivoService = dispositivoService;
        }

        // Lista todos os dispositivos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dispositivos = await _dispositivoService.ListarTodosDispositivos();
            return View(dispositivos);
        }

        // Exibe o formulário para criar um novo dispositivo
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // Recebe os dados do formulário e cria um novo dispositivo
        [HttpPost]
        public async Task<IActionResult> Criar(Dispositivo dispositivo)
        {
            if (!ModelState.IsValid)
            {
                return View(dispositivo);
            }

            await _dispositivoService.AdicionarDispositivo(dispositivo);
            TempData["SuccessMessage"] = "Dispositivo cadastrado com sucesso!";
            return RedirectToAction("Index");
        }

        // Exibe o formulário para editar um dispositivo existente
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var dispositivo = await _dispositivoService.ObterDispositivoPorId(id);
            if (dispositivo == null)
            {
                TempData["ErrorMessage"] = "Dispositivo não encontrado.";
                return RedirectToAction("Index");
            }

            return View(dispositivo);
        }

        // Recebe os dados do formulário e atualiza o dispositivo
        [HttpPost]
        public async Task<IActionResult> Editar(Dispositivo dispositivo)
        {
            if (!ModelState.IsValid)
            {
                return View(dispositivo);
            }

            await _dispositivoService.AtualizarDispositivo(dispositivo);
            TempData["SuccessMessage"] = "Dispositivo atualizado com sucesso!";
            return RedirectToAction("Index");
        }

        // Exclui um dispositivo
        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            var sucesso = await _dispositivoService.DeletarDispositivo(id);
            if (!sucesso)
            {
                TempData["ErrorMessage"] = "Erro ao tentar excluir o dispositivo.";
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = "Dispositivo excluído com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
