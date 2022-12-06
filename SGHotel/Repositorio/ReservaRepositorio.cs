using SGHotel.Models;
using SGHotel.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGHotel.Repositorio
{
    public class ReservaRepositorio : IReservaRespositorio
    {
        private readonly BancoContext _Context;

        public ReservaRepositorio(BancoContext bancoContext)
        {
            _Context = bancoContext;
        }

        public ReservasModel Adicionar(ReservasModel reserva)
        {
            _Context.Reservas.Add(reserva);
            _Context.SaveChanges();

            return reserva;
        }

        public List<ReservasModel> BuscarTodos()
        {
            return _Context.Reservas.ToList();
        }

        public ReservasModel ListarPorId(int id)
        {
            ReservasModel reserva = _Context.Reservas.Where(x => x.id_Reserva == id).FirstOrDefault();

            if(reserva == null)
                throw new System.NotImplementedException("reserva não existe!");

            return reserva;
        }

        public ReservasModel Atualizar(ReservasModel reserva)
        {
            //ContaModel conta_editar = ListarPorId(conta.IdConta);

            if (ListarPorId(reserva.id_Reserva) == null)
                throw new Exception("Conta não encontrada");

            _Context.Reservas.Update(reserva);
            _Context.SaveChanges();

            return reserva;
        }

        public bool Apagar(int id)
        {
            ReservasModel reserva = ListarPorId(id);

            if (ListarPorId(reserva.id_Reserva) == null)
                throw new Exception("reserva não encontrada");

            return true;
        }
    }
}
