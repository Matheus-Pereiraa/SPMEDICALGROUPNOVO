using SENAI_SPMEDICALGROUP_WEBAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SPMEDICALGROUP_WEBAPI.Interfaces
{
    interface IUsuarioMedicoRepository
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>O usuário encontrado</returns>
        UsuarioMedico Login(string email, string senha);

        /// <summary>
        /// Busca por um usuário pelo seu ID
        /// </summary>
        /// <param name="idUsuarioMedico">ID do usuário a ser buscado</param>
        /// <returns>Usuário encontrado</returns>
        UsuarioMedico BuscarPorId(int idUsuarioMedico);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuarioMedico">Recebe os dados de um usuário cadastrado</param>
        void Cadastrar(UsuarioMedico novoUsuarioMedico);

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<UsuarioMedico> Listar();

        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="usuariomedicoAtualizado">Recebe os novos dados do usuário</param>
        void Atualizar(UsuarioMedico usuariomedicoAtualizado);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="idUsuarioMedico"> ID do usuário a ser deletado</param>
        void Deletar(int idUsuarioMedico);
    }
}
