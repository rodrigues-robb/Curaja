using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Curaja.Models
{
    public class UsuarioViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { set; get; }

        [Required]
        public string Senha { set; get; }
    }
}