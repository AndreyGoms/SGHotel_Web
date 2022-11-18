using SGHotel.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SGHotel.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione o tipo de perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
