using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Presenças = new HashSet<Presença>();
        }

        public byte IdSituacao { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Presença> Presenças { get; set; }
    }
}
