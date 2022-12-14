using SGHotel.Models;
using System.Collections.Generic;

namespace SGHotel.Repositorio
{
    public interface IQuartoRepositorio
    {
        public QuartoModel ListarPorId(int id_quarto);
        public List<QuartoModel> BuscaTodos();
        public bool Atualiza_Status(QuartoModel quarto);
        QuartoModel Adicionar(QuartoModel quarto);
        QuartoModel Atualizar(QuartoModel quarto);       
        public bool Apagar(int id_quarto);
    }
}
