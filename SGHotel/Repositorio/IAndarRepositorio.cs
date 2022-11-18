using SGHotel.Models;
using System.Collections.Generic;

namespace SGHotel.Repositorio
{
    public interface IAndarRepositorio
    {
        public List<AndarModel> RetornaTodosAndares();
        public AndarModel AndarPorID(int id);  
    }
}
