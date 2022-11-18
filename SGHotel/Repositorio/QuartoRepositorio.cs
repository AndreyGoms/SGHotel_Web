using SGHotel.Models;
using SGHotel.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGHotel.Repositorio
{
    public class QuartoRepositorio : IQuartoRepositorio
    {
        private readonly BancoContext _context;
        public QuartoRepositorio(BancoContext context)
        {
            _context = context;
        }

        public QuartoModel ListarPorId(int id_quarto)
        {
            return _context.Quartos.Where(x => x.Id_Quarto == id_quarto).FirstOrDefault();
        }

        public List<QuartoModel> BuscaTodos()
        {
            return _context.Quartos.ToList();
        }

        public QuartoModel Adicionar(QuartoModel quarto)
        {
            quarto.Limpo = true;
            _context.Quartos.Add(quarto);   
            _context.SaveChanges();
            return quarto;

        }

        public QuartoModel Atualizar(QuartoModel quarto)
        {
            QuartoModel quarto_editado = ListarPorId(quarto.Id_Quarto);

            if (quarto_editado == null)
                throw new Exception("Quarto não encontrado");

            quarto_editado.Num_quarto = quarto.Num_quarto;
            quarto_editado.Id_Andar = quarto.Id_Andar;
            quarto_editado.Capacidade = quarto.Capacidade;
            quarto_editado.Limpo = quarto.Limpo;

            _context.Quartos.Update(quarto_editado);
            _context.SaveChanges();

            return quarto_editado;
        }


        public bool Apagar(int id)
        {
            QuartoModel Quarto_Deletado = ListarPorId(id);

            if (Quarto_Deletado == null)
                throw new Exception("Houve erro na deleção do quarto!");

            _context.Quartos.Remove(Quarto_Deletado);
            _context.SaveChanges();

            return true;

        }
    }
}
