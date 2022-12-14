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
        bool Apagar(int id);
    }
}
