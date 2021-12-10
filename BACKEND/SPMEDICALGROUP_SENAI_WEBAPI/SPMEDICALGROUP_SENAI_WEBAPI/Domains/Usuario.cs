using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SPMEDICALGROUP_SENAI_WEBAPI.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public byte IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "A senha deve ter de 5 a 20 caracteres")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual Medico Medico { get; set; }

        public virtual UsuarioPaciente UsuarioPaciente { get; set; }

    }
}
