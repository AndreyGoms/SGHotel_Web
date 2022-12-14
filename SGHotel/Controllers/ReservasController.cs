using Microsoft.AspNetCore.Mvc;
using SGHotel.Repositorio;
using SGHotel.Models;

namespace SGHotel.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IReservaRespositorio _reservaRespositorio;
        public ReservasController(IReservaRespositorio reservaRespositorio)
        {
            _reservaRespositorio = reservaRespositorio;
        }

        [HttpPost]
        public IActionResult ApagarConfirmacao(int id_reserva)
        {
            ReservasModel reserva = _reservaRespositorio.ListarPorId(id_reserva);

            return View(reserva);
        }
    }
}
