using Microsoft.AspNetCore.Mvc;
using SGHotel.Models;
using SGHotel.Repositorio;
using System;
using System.Collections.Generic;

namespace SGHotel.Controllers
{
    public class QuartoController : Controller
    {

        private readonly IQuartoRepositorio _quartoRepositorio;

        public QuartoController(IQuartoRepositorio quartoRepositorio)
        {
            _quartoRepositorio = quartoRepositorio;
        }

        public ActionResult Criar()
        {
            return View();
        }


        public ActionResult Editar(int id)
        {
            QuartoModel quarto = _quartoRepositorio.ListarPorId(id);

            return View(quarto);
        }

        //metodos

        [HttpPost]
        public ActionResult Adicionar(QuartoModel quarto)
        {
            try
            {

                if (quarto != null)
                {
                    _quartoRepositorio.Adicionar(quarto);
                    //TempData["MensagemSucesso"] = "quarto cadastrado com sucesso";
                    return RedirectToAction("Criar");
                }

                return View(quarto);
            }
            catch (Exception erro)
            {
                //TempData["MensagemErro"] = "Ops! Não conseguimos cadastrar seu cliente, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Criar");
            }

        }

    }
}
