using Microsoft.EntityFrameworkCore;
using SENAI_SPMEDICALGROUP_WEBAPI.Contexts;
using SENAI_SPMEDICALGROUP_WEBAPI.Domains;
using SENAI_SPMEDICALGROUP_WEBAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SPMEDICALGROUP_WEBAPI.Repositories
{
    public class UsuarioMedicoRepository : IUsuarioMedicoRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(UsuarioMedico usuariomedicoAtualizado)
        {
            UsuarioMedico usuariomedicoBuscado = BuscarPorId(usuariomedicoAtualizado.IdUsuarioMedico);

            if (usuariomedicoAtualizado.Lugar != null)
            {
                usuariomedicoBuscado.Lugar = usuariomedicoAtualizado.Lugar;
            }

            if (usuariomedicoAtualizado.Crm != null)
            {
                usuariomedicoBuscado.Crm = usuariomedicoAtualizado.Crm;
            }


            if (usuariomedicoAtualizado.Especialidade != null)
            {
                usuariomedicoBuscado.Especialidade = usuariomedicoAtualizado.Especialidade;
            }

            if (usuariomedicoBuscado.IdUsuarioMedico != 0)
            {
                usuariomedicoBuscado.IdUsuarioMedico = usuariomedicoAtualizado.IdUsuarioMedico;
            }

            ctx.UsuarioMedicos.Update(usuariomedicoBuscado);

            ctx.SaveChanges();
        }

        public UsuarioMedico BuscarPorId(int idUsuarioMedico)
        {
            return ctx.UsuarioMedicos.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(m => m.IdUsuarioMedico == idUsuarioMedico);
        }

        public void Cadastrar(UsuarioMedico novoUsuarioMedico)
        {
            ctx.UsuarioMedicos.Add(novoUsuarioMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuarioMedico)
        {
            UsuarioMedico medicoBuscado = BuscarPorId(idUsuarioMedico);

            ctx.UsuarioMedicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<UsuarioMedico> Listar()
        {
            return ctx.UsuarioMedicos.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public UsuarioMedico Login(string email, string senha)
        {
            return ctx.UsuarioMedicos.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
