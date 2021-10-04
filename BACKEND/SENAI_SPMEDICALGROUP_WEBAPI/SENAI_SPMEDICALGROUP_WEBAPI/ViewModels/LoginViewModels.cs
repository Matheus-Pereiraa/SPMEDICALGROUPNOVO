using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SPMEDICALGROUP_WEBAPI.ViewModels
{
    public class LoginViewModels
    {

        /// <summary>
        /// Classe responsável pelo modelo de login
        /// </summary>

        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }
    }
}
