using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGHotel.Models;
using SGHotel.Repositorio;
using System;
using System.Collections.Generic;

namespace SGHotel.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public ActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();    
            return View(clientes);
        }

        public ActionResult Criar()
        {
            return View();
        }


        public ActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);

            return View(cliente);
        }

//METODOS
        public ActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _clienteRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "cliente apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar o registro!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos apagar seu Cliente, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]        
        public ActionResult Criar(ClienteModel cliente)
        {
            try
            {
                
                if (cliente != null)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos cadastrar seu cliente, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Index");
            }

        }
  
        [HttpPost]        
        public ActionResult Alterar(ClienteEdicao clienteEdicao)
        {
            try
            {
                ClienteModel cliente;

                if (ModelState.IsValid)
                {
                    cliente = new ClienteModel()
                    {
                        Id = clienteEdicao.Id,
                        Nome = clienteEdicao.Nome,
                        Cpf = clienteEdicao.Cpf,
                        Status = clienteEdicao.Status 
                    };

                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "cliente alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", clienteEdicao);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops! Não conseguimos atualizar seu cliente, tente novamente. Erro:" + erro.Message;
                return RedirectToAction("Index");
            }
        }
    }
    
}

