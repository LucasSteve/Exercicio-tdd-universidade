using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Requests
{
    public class DepartamentoRequest
    {
        [Required(ErrorMessage = "Nome do departamento é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Endereco do departamento é obrigatório.")]
        public EnderecoRequest Endereco { get; set; }
    }
}
