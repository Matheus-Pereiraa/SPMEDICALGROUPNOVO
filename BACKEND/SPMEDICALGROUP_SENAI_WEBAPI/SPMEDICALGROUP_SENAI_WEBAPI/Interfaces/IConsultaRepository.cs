using SPMEDICALGROUP_SENAI_WEBAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMEDICALGROUP_SENAI_WEBAPI.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Altera o status de uma consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta vai ser atualizada</param>
        /// <param name="idSituacao">Id da nova situação de consulta</param>
        void AlterarStatus(int idConsulta, int idSituacao);

        /// <summary>
        /// Vai listar as consultas de um usuario
        /// </summary>
        /// <param name="idUsuario">Id do usuário a ter suas consultas listadas</param>
        List<Consultum> ListarMinhas(int idUsuario);

        /// <summary>
        /// Vai atualizar a descrição de uma consulta 
        /// </summary>
        /// <param name="idConsulta">Id da consulta a ser atualizada</param>
        /// <param name="descricao">Descrição as ser atualizada</param>
        void AddDescricao(int idConsulta, string descricao);    

        /// <summary>
        /// Busca por um consulta pelo seu ID
        /// </summary>
        /// <param name="idConsulta">ID do consulta vai ser buscado</param>
        /// <returns>Consulta encontrada</returns>
        Consultum BuscarPorId(int idConsulta);

        /// <summary>
        /// Cadastra uma consulta
        /// </summary>
        /// <param name="novaConsulta">Recebe os dados de uma consulta cadastrada</param>
        void Cadastrar(Consultum novaConsulta);

        /// <summary>
        /// Vai listar todas as consultas
        /// </summary>
        /// <returns> Essa é a lista de consultas</returns>
        List<Consultum> Listar();

        /// <summary>
        /// Vai atualizar os dados de uma consulta
        /// </summary>
        /// <param name="consultaAtualizada">Recebe os novos dados da consulta</param>
        void Atualizar(Consultum consultaAtualizada);

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="idConsulta"> ID da consulta a ser deletada</param>
        void Deletar(int idConsulta);
    }
}
