using System;
using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class ReservasModel
    {
        [Key]
        public int id_Reserva { get; set; }
        DateTime dt_inicio { get; set; }
        DateTime dt_fim { get; set; }
        int id_cliente { get; set; }
        int id_quarto { get; set; }
    }
}
