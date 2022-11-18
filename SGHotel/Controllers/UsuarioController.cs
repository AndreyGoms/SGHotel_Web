using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using SGHotel.Models;
using SGHotel.Repositorio;
using System;
using System.Collections.Generic;

namespace SGHotel.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar com sucesso!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos apagar seu Usuario, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos cadastrar seu usuario, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemsenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Email = usuarioSemSenhaModel.Email,
                        Login = usuarioSemSenhaModel.Login,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "usuario alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuarioSemSenhaModel);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos atualizar seu usuario, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
