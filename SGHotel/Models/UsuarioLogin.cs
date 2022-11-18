using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "Digite o Usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
