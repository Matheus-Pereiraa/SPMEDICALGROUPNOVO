using System;
using System.Collections.Generic;

#nullable disable

namespace SPMEDICALGROUP_SENAI_WEBAPI.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipoUsuario { get; set; }
        public string TituloTipoUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
