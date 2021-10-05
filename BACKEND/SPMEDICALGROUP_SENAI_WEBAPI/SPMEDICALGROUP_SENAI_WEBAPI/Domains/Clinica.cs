using System;
using System.Collections.Generic;

#nullable disable

namespace SPMEDICALGROUP_SENAI_WEBAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }
        public TimeSpan HorariodeAbertura { get; set; }
        public TimeSpan HorariodeFechamento { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
