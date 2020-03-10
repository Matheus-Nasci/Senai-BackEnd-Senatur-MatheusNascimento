using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O E-mail do Usuário é Obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O E-mail do Usuário é Obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 7, ErrorMessage = "A Senha deve ter no Minímo 7 e no Máximo 30 Caracteres")]
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
