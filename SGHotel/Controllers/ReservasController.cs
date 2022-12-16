using Microsoft.AspNetCore.Mvc;
using SGHotel.Repositorio;
using SGHotel.Models;

namespace SGHotel.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IReservaRespositorio _reservaRespositorio;
        private readonly IContaRepositorio _ContaRespositorio;
        public ReservasController(IReservaRespositorio reservaRespositorio, IContaRepositorio contaRespositorio)
        {
            _reservaRespositorio = reservaRespositorio;
            _ContaRespositorio = contaRespositorio;
        }


        [HttpPost]
        public ActionResult Cancela_Conta_Reserva(int id_reserva)
        {
            ReservasModel reserva_apagar = _reservaRespositorio.ListarPorId(id_reserva);
            ContaModel conta_ref = _ContaRespositorio.ListarPorId(reserva_apagar.id_Conta);
            
            ContaModel conta_att = new ContaModel();
            conta_att.IdConta = conta_ref.IdConta;
            conta_att.Valor_Conta = conta_ref.Valor_Conta;
            conta_att.Descricao = conta_ref.Descricao + " [Cancelada]";
            conta_att.dt_vencimento = conta_ref.dt_vencimento;
            conta_att.dt_lancamento = conta_ref.dt_lancamento;
            conta_att.tp_conta = "Cancelada";
                      
            var result_conta =  _ContaRespositorio.Cancelar(conta_att);
            var result_reserva = _reservaRespositorio.Apagar(reserva_apagar.id_Reserva);                       

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult ApagarConfirmacao(int id_reserva)
        {
            ReservasModel reserva = _reservaRespositorio.ListarPorId(id_reserva);

            return View(reserva);
        }
    }
}
