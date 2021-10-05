using System;
using System.Collections.Generic;

#nullable disable

namespace SPMEDICALGROUP_SENAI_WEBAPI.Domains
{
    public partial class UsuarioPaciente
    {
        public UsuarioPaciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
