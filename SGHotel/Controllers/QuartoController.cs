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
        private readonly IClienteRepositorio _clientesRepositorio;
        private readonly IReservaRespositorio _reservaRepositorio;
        private readonly IContaRepositorio _contaRepositorio;

        public QuartoController(IQuartoRepositorio quartoRepositorio, IClienteRepositorio clientesRepositorio, IReservaRespositorio reservaRepositorio, IContaRepositorio contaRepositorio)
        {
            _quartoRepositorio = quartoRepositorio;
            _clientesRepositorio = clientesRepositorio;
            _reservaRepositorio = reservaRepositorio;
            _contaRepositorio = contaRepositorio;
        }

        public ActionResult Criar()
        {
            return View();
        }

        public ActionResult Detalhes(int id)
        {
            QuartoModel quarto = _quartoRepositorio.ListarPorId(id);
            quarto.Clientes = _clientesRepositorio.BuscarTodos();
            quarto.reservas = _reservaRepositorio.BuscarReservas(id);    

            return View(quarto);
        }

        public ActionResult Editar(int id)
        {
            QuartoModel quarto = _quartoRepositorio.ListarPorId(id);

            return View(quarto);
        }


        public ActionResult solicitar_limpeza(int id_quarto)
        {
            var quarto = _quartoRepositorio.Sujar(id_quarto);



            return Redirect(@"https://localhost:44387/Quarto/Detalhes/" + id_quarto);
        }


        public ActionResult Check_In_Out(int id_quarto, int id_reserva)
        {
            QuartoModel quarto = _quartoRepositorio.ListarPorId(id_quarto);

            if(id_reserva != 0)
            {
                    ReservasModel reserva = _reservaRepositorio.ListarPorId(id_reserva);

                    reserva.dt_fim = DateTime.Now;

                    ReservasModel reserva_att = _reservaRepositorio.Atualizar(reserva);
            }

            var result = _quartoRepositorio.Atualiza_Status(quarto);

            return RedirectToAction("Index", "Home");
        }


        public ActionResult ApagarConfirmacao(int id_reserva)
        {
            ReservasModel reserva_localizada = _reservaRepositorio.ListarPorId(id_reserva);
            ClienteModel cliente_da_reserva = _clientesRepositorio.ListarPorId(reserva_localizada.id_cliente);
            reserva_localizada.Nome_Cliente = cliente_da_reserva.Nome;



            return View(reserva_localizada);
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


        [HttpPost]
        public ActionResult Editar(QuartoModel quartoEditado)
        {            
            var result =  _quartoRepositorio.Atualizar(quartoEditado);

            return RedirectToAction("Index","Home");
        }
              
        
        [HttpPost]
        public RedirectResult Adicionar_Reserva(ReservasModel reserva)
        {
            var all_reservas = _reservaRepositorio.BuscarReservas(reserva.id_quarto);
            QuartoModel quarto = _quartoRepositorio.ListarPorId(reserva.id_quarto);
            

            foreach (var reservas in all_reservas)
            {
                if(VerificaData(reservas.dt_inicio, reservas.dt_fim, reserva.dt_inicio, reserva.dt_fim))
                {
                    TempData["MensagemErro"] = "Data invalida! Choque com outra reserva.";
                    return Redirect(@"https://localhost:44387/Quarto/Detalhes/" + reserva.id_quarto);
                }
            }

            
            ContaModel obj_conta = new ContaModel();
            obj_conta.tp_conta = "Receber";
            obj_conta.Valor_Conta = reserva.Valor_pago;
            obj_conta.Descricao = "Reserva quarto de quarto: " + quarto.Num_quarto;
            obj_conta.dt_lancamento = reserva.dt_inicio;
            obj_conta.dt_vencimento = reserva.dt_fim;           

            var conta_criada = _contaRepositorio.Criar(obj_conta);
            reserva.id_Conta = conta_criada.IdConta;
            var resrva_a_fazer = _reservaRepositorio.Adicionar(reserva);
                
            return Redirect(@"https://localhost:44387/Quarto/Detalhes/" + reserva.id_quarto);            
        }


        public bool VerificaData(DateTime data_inicio, DateTime data_fim, DateTime data_verif_inicio, DateTime data_verif_fim)
        {
            if(data_inicio <= data_verif_inicio && data_verif_inicio <= data_fim)
                return true;
            
            
            if(data_inicio <= data_verif_fim && data_verif_fim <= data_fim)
                return true;
            
            return false;
        }

    }
}
