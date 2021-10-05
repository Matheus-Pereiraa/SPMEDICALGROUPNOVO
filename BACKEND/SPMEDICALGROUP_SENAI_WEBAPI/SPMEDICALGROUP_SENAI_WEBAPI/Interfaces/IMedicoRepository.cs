using SPMEDICALGROUP_SENAI_WEBAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMEDICALGROUP_SENAI_WEBAPI.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Vai buscar um médico pelo seu ID
        /// </summary>
        /// <param name="idMedico">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        Medico BuscarPorId(int idMedico);

        /// <summary>
        /// Vai cadastrar um médico
        /// </summary>
        /// <param name="novoMedico">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Vai listar todos os médicos
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<Medico> Listar();

        /// <summary>
        /// Vai atualizar os dados de um médico
        /// </summary>
        /// <param name="MedicoAtualizado">Recebe os novos dados do médico</param>
        void Atualizar(Medico MedicoAtualizado);

        /// <summary>
        /// Deleta um médico
        /// </summary>
        /// <param name="idMedico"> ID do médico a ser deletado</param>
        void Deletar(int idMedico);
    }
}
