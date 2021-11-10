using SPMEDICALGROUP_SENAI_WEBAPI.Context;
using SPMEDICALGROUP_SENAI_WEBAPI.Domains;
using SPMEDICALGROUP_SENAI_WEBAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMEDICALGROUP_SENAI_WEBAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPmedContext ctx = new SPmedContext();
        public void Atualizar(Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(clinicaAtualizada.IdClinica);
            clinicaBuscada.HorariodeAbertura = clinicaAtualizada.HorariodeAbertura;
            clinicaBuscada.HorariodeFechamento = clinicaAtualizada.HorariodeFechamento;

            if (clinicaAtualizada.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            }

            if (clinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }

            if (clinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }

            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
