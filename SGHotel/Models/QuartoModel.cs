using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class QuartoModel
    {
        [Key]
        public int Id_Quarto { get; set; }
        public string Num_quarto { get; set; }
        public double Preco { get; set; }
        public int Capacidade { get; set; }
        public int Id_Andar { get; set; }
        public bool Limpo { get; set; }        
        public bool Disponivel { get; set; }
        List<ReservasModel> reservas { get; set; }
    }
}
