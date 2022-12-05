using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHotel.Models;
using SGHotel.Repositorio;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SGHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IQuartoRepositorio _quartoRepositorio;
        public HomeController(ILogger<HomeController> logger, IQuartoRepositorio quartoRepositorio)
        {
            _logger = logger;
            _quartoRepositorio = quartoRepositorio;
        }

        public IActionResult Index()
        {

            List<QuartoModel> quartos = _quartoRepositorio.BuscaTodos();

            return View(quartos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
