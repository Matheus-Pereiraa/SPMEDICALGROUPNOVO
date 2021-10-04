using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Domains
{
    public partial class Consulta
    {
        public Consulta()
        {
            Presenças = new HashSet<Presença>();
        }

        public byte IdConsulta { get; set; }
        public byte? IdLugar { get; set; }
        public byte? IdTipoConsulta { get; set; }
        public string Descricao { get; set; }
        public string DataConsulta { get; set; }
        public byte? IdUsuarioPaciente { get; set; }
        public byte? IdUsuarioMedico { get; set; }

        public virtual Lugar IdLugarNavigation { get; set; }
        public virtual TipoConsultum IdTipoConsultaNavigation { get; set; }
        public virtual UsuarioMedico IdUsuarioMedicoNavigation { get; set; }
        public virtual UsuarioPaciente IdUsuarioPacienteNavigation { get; set; }
        public virtual ICollection<Presença> Presenças { get; set; }
    }
}
