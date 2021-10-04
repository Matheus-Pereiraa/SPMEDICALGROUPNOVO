using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class TipoConsultum
    {
        public TipoConsultum()
        {
            Consulta = new HashSet<Consulta>();
        }

        public byte IdTipoConsulta { get; set; }
        public string TipoDaConsulta { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
