using SENAI_SPMEDICALGROUP_WEBAPI.Contexts;
using SENAI_SPMEDICALGROUP_WEBAPI.Domains;
using SENAI_SPMEDICALGROUP_WEBAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SPMEDICALGROUP_WEBAPI.Repositories
{
    public class UsuarioPacienteRepository : IUsuarioPacienteRepository
    {

        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(UsuarioPaciente usuariopacienteAtualizado)
        {
            UsuarioPaciente usuariopacienteBuscado = BuscarPorId(usuariopacienteAtualizado.IdUsuarioPaciente);

            if (usuariopacienteAtualizado.NomeUsuarioPaciente != null)
            {
                usuariopacienteBuscado.NomeUsuarioPaciente = usuariopacienteAtualizado.NomeUsuarioPaciente;
            }
            if (usuariopacienteAtualizado.Email != null)
            {
                usuariopacienteBuscado.Email = usuariopacienteAtualizado.Email;
            }

            if (usuariopacienteAtualizado.Senha != null)
            {
                usuariopacienteBuscado.Senha = usuariopacienteAtualizado.Senha;
            }

            ctx.UsuarioPaciente.Update(usuariopacienteBuscado);

            ctx.SaveChanges();
        }

        public UsuarioPaciente BuscarPorId(int idUsuarioPaciente)
        {
            return ctx.UsuarioPaciente.FirstOrDefault(u => u.IdUsuarioPaciente == idUsuarioPaciente);
        }

        public void Cadastrar(UsuarioPaciente novoUsuarioPaciente)
        {
            ctx.UsuarioPaciente.Add(novoUsuarioPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuarioPaciente)
        {
            UsuarioPaciente usuariopacienteBuscado = BuscarPorId(idUsuarioPaciente);

            ctx.UsuarioPaciente.Remove(usuariopacienteBuscado);

            ctx.SaveChanges();
        }

        public List<UsuarioPaciente> Listar()
        {
            return ctx.UsuarioPaciente.ToList();
        }

        public UsuarioPaciente Login(string email, string senha)
        {
            return ctx.UsuarioPaciente.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
