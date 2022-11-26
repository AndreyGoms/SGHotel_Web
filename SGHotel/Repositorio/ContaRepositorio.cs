using SGHotel.Models;
using SGHotel.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGHotel.Repositorio
{
    public class ContaRepositorio : IContaRepositorio
    {

        private readonly BancoContext _context;

        public ContaRepositorio(BancoContext context)
        {
            _context = context;
        }

        public ContaModel ListarPorId(int id)
        {
            return _context.Contas.Where(x => x.IdConta == id).FirstOrDefault();
             
        }

        public List<ContaModel> BuscaTodos()
        {
            return _context.Contas.ToList();
        }

        public ContaModel Criar(ContaModel conta)
        {            
            _context.Contas.Add(conta);
            _context.SaveChanges();

            return conta;
        }

        public ContaModel Editar(ContaModel conta)
        {
            //ContaModel conta_editar = ListarPorId(conta.IdConta);

            if (ListarPorId(conta.IdConta) == null)
                throw new Exception("Conta não encontrada");

            _context.Contas.Update(conta);
            _context.SaveChanges();

            return conta;

        }

        public bool Apagar(ContaModel conta)
        {
            ContaModel conta_apagar = ListarPorId(conta.IdConta);

            if (conta_apagar == null)
                throw new Exception("Conta não encontrada");


            _context.Contas.Remove(conta_apagar);
            _context.SaveChanges();


            return true;
        }

    }
}
