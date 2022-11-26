using System;
using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class ContaModel
    {
        [Key]
        public int IdConta { get; set; }
        public string Descricao { get; set; }
        public double Valor_Conta { get; set; }
        public DateTime dt_lancamento { get; set; }
        public DateTime dt_vencimento { get; set; }
        public string tp_conta { get; set; }
    }
}
