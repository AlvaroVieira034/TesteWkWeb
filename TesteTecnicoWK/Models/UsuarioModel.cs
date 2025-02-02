using TesteTecnicoWK.Enums;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Cod_Usuario { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Des_NomeUsuario { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Des_Email { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Des_Login { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Cod_Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Des_Senha { get; set; }
        public DateTime Dta_Cadastro { get; set; }
        public DateTime? Dta_Atualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Des_Senha == senha;
        }
    }
}
