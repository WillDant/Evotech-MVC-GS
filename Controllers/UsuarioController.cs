using Microsoft.AspNetCore.Mvc;
using ProjetoMvc.DTO;
using ProjetoMvc.Models;
using ProjetoMvc.Services;
using System.Threading.Tasks;

namespace ProjetoMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Exibe o formulário para criar um novo usuário
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // Recebe os dados do formulário e cria um novo usuário
        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioDTO usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nome = usuarioDto.Nome,
                    Email = usuarioDto.Email,
                    Senha = usuarioDto.Senha
                };

                await _usuarioService.Adicionar(usuario);

                TempData["SuccessMessage"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuarioDto);
        }

        // Lista todos os usuários
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ListarTodos();
            return View(usuarios);
        }

        // Exibe o formulário para editar um usuário existente
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioService.ObterPorId(id);
            if (usuario == null)
            {
                TempData["ErrorMessage"] = "Usuário não encontrado.";
                return RedirectToAction("Index");
            }

            var usuarioDto = new UsuarioDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            return View(usuarioDto);
        }

        // Recebe os dados do formulário e atualiza o usuário
        [HttpPost]
        public async Task<IActionResult> Editar(int id, UsuarioDTO usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Id = id,
                    Nome = usuarioDto.Nome,
                    Email = usuarioDto.Email,
                    Senha = usuarioDto.Senha
                };

                await _usuarioService.Atualizar(usuario);

                TempData["SuccessMessage"] = "Usuário atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuarioDto);
        }

        // Confirma a exclusão de um usuário
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            var usuario = await _usuarioService.ObterPorId(id);
            if (usuario == null)
            {
                TempData["ErrorMessage"] = "Usuário não encontrado.";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // Exclui um usuário
        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDeletar(int id)
        {
            var sucesso = await _usuarioService.Deletar(id);
            if (!sucesso)
            {
                TempData["ErrorMessage"] = "Erro ao tentar excluir o usuário.";
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = "Usuário excluído com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
