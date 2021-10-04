using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class UsuarioMedico
    {
        public UsuarioMedico()
        {
            Consulta = new HashSet<Consulta>();
            Presenças = new HashSet<Presença>();
        }

        public byte IdUsuarioMedico { get; set; }

        public string Lugar { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string Crm { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 20 caracteres")]
        public string Senha { get; set; }
        public string Especialidade { get; set; }
        public string Clinica { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Presença> Presenças { get; set; }
    }
}
