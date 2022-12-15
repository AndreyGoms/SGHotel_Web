using System;
using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class ReservasModel
    {
        [Key]
        public int id_Reserva { get; set; }
        public DateTime dt_inicio { get; set; }
        public DateTime dt_fim { get; set; }
        public int id_cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public int id_quarto { get; set; }
        public double Valor_pago { get; set; }
    }
}
