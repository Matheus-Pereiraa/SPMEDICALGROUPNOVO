using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            UsuarioMedicos = new HashSet<UsuarioMedico>();
            UsuarioPacientes = new HashSet<UsuarioPaciente>();
        }

        public byte IdTipoUsuario { get; set; }
        public string NomeTipoUsuario { get; set; }

        public virtual ICollection<UsuarioMedico> UsuarioMedicos { get; set; }
        public virtual ICollection<UsuarioPaciente> UsuarioPacientes { get; set; }
    }
}
