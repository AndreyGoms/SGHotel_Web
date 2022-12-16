using Microsoft.AspNetCore.Mvc;
using SGHotel.Models;
using SGHotel.Repositorio;
using System.Collections.Generic;

namespace SGHotel.Controllers
{
    public class ServGeraisController : Controller
    {

        private readonly IQuartoRepositorio _quartoRepositorio;
        private readonly IClienteRepositorio _clientesRepositorio;
        private readonly IReservaRespositorio _reservaRepositorio;
        private readonly IContaRepositorio _contaRepositorio;
        public ServGeraisController(IQuartoRepositorio quartoRepositorio, IClienteRepositorio clientesRepositorio, IReservaRespositorio reservaRepositorio, IContaRepositorio contaRepositorio)
        {
            _quartoRepositorio = quartoRepositorio;
            _clientesRepositorio = clientesRepositorio;
            _reservaRepositorio = reservaRepositorio;
            _contaRepositorio = contaRepositorio;
        }

        public IActionResult Index()
        {
            /*
                numero do quarto
                dt saida
                nome do cliente
                limpar?            
             */
            //List<QuartoModel> quartos = _quartoRepositorio.Quartos_Limpeza();                                             

            List<Limpeza> limpezaList = _reservaRepositorio.quartos_limpeza();

            return View(limpezaList);
        }
        
        public IActionResult limpeza(int id_quarto)
        {
            var result = _quartoRepositorio.Limpar(id_quarto);


            return RedirectToAction("Index");
        }


    }
}
