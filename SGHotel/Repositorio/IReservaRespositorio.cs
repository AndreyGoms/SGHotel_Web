using SGHotel.Models;
using System.Collections.Generic;

namespace SGHotel.Repositorio
{
    public interface IReservaRespositorio
    {
        ReservasModel ListarPorId(int id);
        List<ReservasModel> BuscarTodos();
        List<ReservasModel> BuscarReservas(int id_quarto);
        ReservasModel Adicionar(ReservasModel reserva);
        ReservasModel Atualizar(ReservasModel reserva);
        public List<Limpeza> quartos_limpeza();
        bool Apagar(int id);
    }
}
