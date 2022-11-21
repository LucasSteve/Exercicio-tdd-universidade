using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Requests
{
    public class AutenticacaoRequest
    {
        [Required(ErrorMessage = "O campo 'Email' é obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' é obrigatorio")]
        public string Senha { get; set; }

    }
}
