using SENAI_SPMEDICALGROUP_WEBAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SPMEDICALGROUP_WEBAPI.Interfaces
{
    interface IUsuarioPacienteRepository
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>O usuário encontrado</returns>
        UsuarioPaciente Login(string email, string senha);

        /// <summary>
        /// Busca por um usuário pelo seu ID
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        UsuarioPaciente BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(UsuarioPaciente novoUsuario);

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<UsuarioPaciente> Listar();

        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="usuariopacienteAtualizado">Recebe os novos dados do usuário</param>
        void Atualizar(UsuarioPaciente usuariopacienteAtualizado);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idUsuarioPaciente"> ID do usuário a ser deletado</param>
        void Deletar(int idUsuarioPaciente);
    }
}
