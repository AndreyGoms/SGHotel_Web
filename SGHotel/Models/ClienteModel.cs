using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF do usuario")]
        public string Cpf { get; set; }
        public bool Status { get; set; }
    }
}
