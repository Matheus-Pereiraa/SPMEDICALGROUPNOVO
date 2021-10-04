using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class Presença
    {
        public byte IdPresença { get; set; }
        public byte? IdUsuarioPaciente { get; set; }
        public byte? IdUsuarioMedico { get; set; }
        public byte? IdSituacao { get; set; }
        public byte? IdConsulta { get; set; }

        public virtual Consulta IdConsultaNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
        public virtual UsuarioMedico IdUsuarioMedicoNavigation { get; set; }
        public virtual UsuarioPaciente IdUsuarioPacienteNavigation { get; set; }
    }
}
