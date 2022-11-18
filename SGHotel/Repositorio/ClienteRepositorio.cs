using SGHotel.Models;
using SGHotel.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGHotel.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            cliente.Status = true;
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel ClienteEditado = ListarPorId(cliente.Id);

            if (ClienteEditado == null)
                throw new Exception("Cliente não encontrado");

            ClienteEditado.Nome = cliente.Nome;
            ClienteEditado.Cpf = cliente.Cpf;
            ClienteEditado.Status = cliente.Status;

            _bancoContext.Clientes.Update(ClienteEditado);
            _bancoContext.SaveChanges();

            return ClienteEditado;
        }
        
        public bool Apagar(int id)
        {
            ClienteModel cliente = ListarPorId(id);

            if (cliente == null)
                throw new Exception("Houve erro na deleção do cliente");

            _bancoContext.Clientes.Remove(cliente);
            _bancoContext.SaveChanges();

            return true;

        }


    }
}
