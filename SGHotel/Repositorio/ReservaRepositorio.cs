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


        public List<ReservasModel> BuscarReservas(int id_quarto)
        {

            List<ReservasModel> reservas_do_quarto = _Context.Reservas.Where(x => x.id_quarto == id_quarto).ToList(); 

            return reservas_do_quarto;
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

            _Context.Reservas.Remove(reserva);
            _Context.SaveChanges();

            return true;
        }

        public List<Limpeza> quartos_limpeza()
        {

            var reservas_fim_hoje = _Context.Reservas.Where(x=> x.dt_fim.Date == DateTime.Today).ToList();


            QuartoRepositorio quartoRepositorio = new QuartoRepositorio(_Context);
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio(_Context);
            List<Limpeza> lista_de_limpeza = new List<Limpeza>();
            
           
            List<QuartoModel> lista_quartos = quartoRepositorio.BuscaTodos();


            foreach (var reserva in reservas_fim_hoje)
            {
                foreach (var quarto in lista_quartos)
                {
                    if((reserva.id_quarto == quarto.Id_Quarto) && (!quarto.Limpo))
                    {
                        Limpeza obj_limpeza = new Limpeza();
                        var cliente = clienteRepositorio.ListarPorId(reserva.id_cliente);
                        
                        obj_limpeza.Num_quarto = quarto.Num_quarto;
                        obj_limpeza.dt_saida = reserva.dt_fim;
                        obj_limpeza.Nome_Cliente = cliente.Nome;
                        obj_limpeza.id_quarto = quarto.Id_Quarto;

                        lista_de_limpeza.Add(obj_limpeza);
                    } 
                    else if(!quarto.Limpo)
                    {
                        Limpeza obj_limpeza = new Limpeza();
                        obj_limpeza.Num_quarto = quarto.Num_quarto;
                        obj_limpeza.dt_saida = DateTime.Today;
                        obj_limpeza.Nome_Cliente = "Solicitação de limpeza";
                        obj_limpeza.id_quarto = quarto.Id_Quarto;
                        lista_de_limpeza.Add(obj_limpeza);
                    }
                }
            }


            return lista_de_limpeza;
        }

    }
}
