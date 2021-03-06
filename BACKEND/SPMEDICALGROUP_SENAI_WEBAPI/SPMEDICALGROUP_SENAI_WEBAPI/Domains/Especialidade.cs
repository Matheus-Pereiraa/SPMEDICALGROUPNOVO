using System;
using System.Collections.Generic;

#nullable disable

namespace SPMEDICALGROUP_SENAI_WEBAPI.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdEspecialidade { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
