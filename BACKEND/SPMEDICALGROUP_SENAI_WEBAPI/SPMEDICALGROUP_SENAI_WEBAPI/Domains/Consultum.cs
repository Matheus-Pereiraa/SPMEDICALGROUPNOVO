using System;
using System.Collections.Generic;

#nullable disable

namespace SPMEDICALGROUP_SENAI_WEBAPI.Domains
{

    /// <summary>
    /// Classe que representa entidade de Consultas
    /// </summary>
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime DataeHora { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual UsuarioPaciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
