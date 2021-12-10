using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMEDICALGROUP_SENAI_WEBAPI.Domains;
using SPMEDICALGROUP_SENAI_WEBAPI.Interfaces;
using SPMEDICALGROUP_SENAI_WEBAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMEDICALGROUP_SENAI_WEBAPI.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPacienteController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos da interface
        /// </summary>
        private IUsuarioPacienteRepository _pacienteRepository { get; set; }

        /// <summary>
        /// Instanciar objeto para que haja referência feitas no repositório
        /// </summary>
        public UsuarioPacienteController()
        {
            _pacienteRepository = new UsuarioPacienteRepository();
        }

        /// <summary>
        /// Lista todos os Pacientes que existentem
        /// </summary>
        /// <returns>Uma lista de pacientes com o status code 200 - Ok</returns>
        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_pacienteRepository.Listar());
        }

        /// <summary>
        /// Busca um paciente pelo seu id
        /// </summary>
        /// <param name="idPaciente">id do paciente a ser buscado</param>
        /// <returns>Um paciente encontrado com o status code 200 - Ok</returns>
        [Authorize(Roles = "1,2")]
        [HttpGet("{idPaciente}")]
        public IActionResult BuscarPorId(int idPaciente)
        {
            UsuarioPaciente PacienteBuscado = _pacienteRepository.BuscarPorId(idPaciente);

            if (PacienteBuscado == null)
            {
                return NotFound("O Paciente informado não existe!");
            }
            return Ok(PacienteBuscado);
        }

        /// <summary>
        /// Cadastra um Paciente
        /// </summary>
        /// <param name="novoPaciente">Paciente a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1,2")]
        [HttpPost]
        public IActionResult Cadastrar(UsuarioPaciente novoPaciente)
        {
            if (novoPaciente.DataNascimento < DateTime.Now)
            {
                _pacienteRepository.Cadastrar(novoPaciente);
            }
            else
            {

                return BadRequest(new { mensagem = "Teriamos o primeiro viajante do tempo?!" });
            }

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="pacienteAtualizado">Objeto com as novas informações do Paciente e o id do paciente a ser atualizado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1,2")]
        [HttpPut]
        public IActionResult Atualizar(UsuarioPaciente pacienteAtualizado)
        {
            try
            {
                if (pacienteAtualizado.DataNascimento < DateTime.Now)
                {
                    UsuarioPaciente PacienteBuscado = _pacienteRepository.BuscarPorId(pacienteAtualizado.IdPaciente);

                    if (PacienteBuscado != null)
                    {
                        if (pacienteAtualizado != null)
                            _pacienteRepository.Atualizar(pacienteAtualizado);

                    }
                    else
                    {
                        return BadRequest(new { mensagem = "O Paciente informado não existe" });
                    }
                    return StatusCode(204);
                }
                else
                {
                    return BadRequest(new { mensagem = "Teriamos o primeiro viajante do tempo?!" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="idPaciente">id do Paciente a ser deletado</param>
        /// <returns>Um status code 204 - No content</returns>
        [Authorize(Roles = "1,2")]
        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int idPaciente)
        {
            _pacienteRepository.Deletar(idPaciente);

            return StatusCode(204);
        }



    }
}
