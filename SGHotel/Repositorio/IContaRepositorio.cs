using SGHotel.Models;
using System.Collections.Generic;

namespace SGHotel.Repositorio
{
    public interface IContaRepositorio
    {
        public List<ContaModel> BuscaTodos();
        public ContaModel ListarPorId(int id);
        public ContaModel Criar(ContaModel conta);
        public ContaModel Editar(ContaModel conta);
        public bool Cancelar(ContaModel conta_cancelar);
        public bool Apagar(ContaModel conta);
    }
}
