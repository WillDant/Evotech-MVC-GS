using Microsoft.AspNetCore.Mvc;
using ProjetoMvc.DTO;
using ProjetoMvc.Models;
using ProjetoMvc.Services;

namespace ProjetoMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

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
                return RedirectToAction("Criar");
            }

            return View(usuarioDto);
        }
    }
}
