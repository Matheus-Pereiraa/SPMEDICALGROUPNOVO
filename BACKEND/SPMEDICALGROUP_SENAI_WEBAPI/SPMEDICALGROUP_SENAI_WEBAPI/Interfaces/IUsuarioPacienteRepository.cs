using SPMEDICALGROUP_SENAI_WEBAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMEDICALGROUP_SENAI_WEBAPI.Interfaces
{
    interface IUsuarioPacienteRepository
    {
        /// <summary>
        /// Vai buscar um paciente pelo seu ID
        /// </summary>
        /// <param name="idPaciente">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        UsuarioPaciente BuscarPorId(int idPaciente);

        /// <summary>
        /// Vai cadastrar um paciente
        /// </summary>
        /// <param name="novoPaciente">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(UsuarioPaciente novoPaciente);

        /// <summary>
        /// Vai listar todos os pacientes
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<UsuarioPaciente> Listar();

        /// <summary>
        /// Vai atualizar os dados de um paciente
        /// </summary>
        /// <param name="PacienteAtualizado">Recebe os novos dados do paciente</param>
        void Atualizar(UsuarioPaciente PacienteAtualizado);

        /// <summary>
        /// Vai deletar um paciente
        /// </summary>
        /// <param name="idPaciente"> ID do paciente a ser deletado</param>
        void Deletar(int idPaciente);
    }
}
