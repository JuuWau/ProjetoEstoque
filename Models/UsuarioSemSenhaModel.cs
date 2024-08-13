using Estoque.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Models{
    public class UsuarioSemSenhaModel{
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Escolha o tipo de perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
    }
}
