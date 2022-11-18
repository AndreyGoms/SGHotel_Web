using SGHotel.Models;
using SGHotel.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SGHotel.Repositorio
{
    public class AndarRepositorio : IAndarRepositorio
    {
        private readonly BancoContext _context;

        public AndarRepositorio (BancoContext context)
        {
            _context = context;
        }

        public AndarModel AndarPorID(int id)
        {
            return _context.Andares.Where(x => x.IdAndar == id).FirstOrDefault();   
        }

        public List<AndarModel> RetornaTodosAndares()
        {
            return _context.Andares.ToList();
        }
    }
}
