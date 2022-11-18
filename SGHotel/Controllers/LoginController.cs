using Microsoft.AspNetCore.Mvc;
using SGHotel.Models;
using SGHotel.Repositorio;
using System;

namespace SGHotel.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(UsuarioLogin usuarioLogin)
        {
            try
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorLOgin(usuarioLogin.Usuario);

                if (usuario != null)
                {
                    if (usuario.SenhaValida(usuarioLogin.Senha))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = "Senha inválida. Tente novamente.";
                }

                TempData["MensagemErro"] = "Usuario e/ou senha inválido(s). Tente novamente.";

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos realizar seu login, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Index");
            }

        }

    }
}
