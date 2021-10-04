using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class UsuarioPaciente
    {
        public UsuarioPaciente()
        {
            Consulta = new HashSet<Consulta>();
            Presenças = new HashSet<Presença>();
        }

        public byte IdUsuarioPaciente { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string NomeUsuarioPaciente { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereço { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 20 caracteres")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Presença> Presenças { get; set; }
    }
}
