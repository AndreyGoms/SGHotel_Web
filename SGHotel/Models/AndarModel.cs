using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class AndarModel
    {
        [Key]
        public int IdAndar { get; set; }
        public int Num_Andar { get; set; }
    }
}
