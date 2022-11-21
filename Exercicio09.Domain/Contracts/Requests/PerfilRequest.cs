using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Requests
{
    public class PerfilRequest
    {
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Nome { get; set; }
    }
}
