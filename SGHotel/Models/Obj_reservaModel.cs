using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGHotel.Models
{
    public class Obj_reservaModel
    {                
        public DateTime dt_inicio { get; set; }
        public DateTime dt_fim { get; set; }
        public int id_cliente { get; set; }
        public int id_quarto { get; set; }
    }
}
