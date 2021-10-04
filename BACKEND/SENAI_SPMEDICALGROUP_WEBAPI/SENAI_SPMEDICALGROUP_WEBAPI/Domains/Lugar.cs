using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class Lugar
    {
        public Lugar()
        {
            Consulta = new HashSet<Consulta>();
        }

        public byte IdLugar { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public string HorarioFuncionamento { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
