using Estoque.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Models{
    public class UsuarioModel{
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataEdicao { get; set; }
        public PerfilEnum? Perfil { get; set; }

        public bool SenhaValida(string senha){
            return Senha == senha;
        }
    }
}
