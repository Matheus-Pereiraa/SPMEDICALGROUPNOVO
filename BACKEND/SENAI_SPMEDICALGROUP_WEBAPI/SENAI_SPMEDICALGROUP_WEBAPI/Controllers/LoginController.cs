using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SENAI_SPMEDICALGROUP_WEBAPI.Domains;
using SENAI_SPMEDICALGROUP_WEBAPI.Interfaces;
using SENAI_SPMEDICALGROUP_WEBAPI.Repositories;
using SENAI_SPMEDICALGROUP_WEBAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SENAI_SPMEDICALGROUP_WEBAPI.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioMedicoRepository _UsuarioMedicoRepository { get; set; }

        public LoginController()
        {
            _UsuarioMedicoRepository = new UsuarioMedicoRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModels Login)
        {
            try
            {
                UsuarioMedico usuariomedicoBuscado = _UsuarioMedicoRepository.Login(Login.Email, Login.Senha);

                if (usuariomedicoBuscado == null)
                {
                    return BadRequest("O Email ou a senha estão invalidos");
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuariomedicoBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuariomedicoBuscado.IdUsuarioMedico.ToString()),
                    new Claim(ClaimTypes.Role, usuariomedicoBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-SpMedical"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer:             "spMedical.webAPI",
                    audience:           "spMedical.webAPI",
                    claims:             minhasClaims,
                    expires:            DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
