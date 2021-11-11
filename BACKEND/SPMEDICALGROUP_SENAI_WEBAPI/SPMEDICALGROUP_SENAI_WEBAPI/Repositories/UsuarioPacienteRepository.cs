using Microsoft.EntityFrameworkCore;
using SPMEDICALGROUP_SENAI_WEBAPI.Context;
using SPMEDICALGROUP_SENAI_WEBAPI.Domains;
using SPMEDICALGROUP_SENAI_WEBAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMEDICALGROUP_SENAI_WEBAPI.Repositories
{
    public class UsuarioPacienteRepository : IUsuarioPacienteRepository
    {
        SPmedContext ctx = new SPmedContext();

        public void Atualizar(UsuarioPaciente PacienteAtualizado)
        {
            UsuarioPaciente pacienteBuscado = BuscarPorId(PacienteAtualizado.IdPaciente);

            pacienteBuscado.DataNascimento = PacienteAtualizado.DataNascimento;

            if (PacienteAtualizado.IdUsuario != 0)
            {
                pacienteBuscado.IdUsuario = PacienteAtualizado.IdUsuario;
            }

            if (PacienteAtualizado.Cpf != null)
            {
                pacienteBuscado.Cpf = PacienteAtualizado.Cpf;
            }

            if (PacienteAtualizado.Endereco != null)
            {
                pacienteBuscado.Endereco = PacienteAtualizado.Endereco;
            }

            if (PacienteAtualizado.Rg != null)
            {
                pacienteBuscado.Rg = PacienteAtualizado.Rg;
            }

            if (PacienteAtualizado.Telefone != null)
            {
                pacienteBuscado.Telefone = PacienteAtualizado.Telefone;
            }

            ctx.UsuarioPacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public UsuarioPaciente BuscarPorId(int idPaciente)
        {
            return ctx.UsuarioPacientes.Include(u => u.IdUsuarioNavigation).FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public void Cadastrar(UsuarioPaciente novoPaciente)
        {
            ctx.UsuarioPacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            UsuarioPaciente pacienteBuscado = BuscarPorId(idPaciente);

            ctx.UsuarioPacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<UsuarioPaciente> Listar()
        {
            return ctx.UsuarioPacientes.Include(u => u.IdUsuarioNavigation).ToList();
        }
    }
}
