using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Requests
{
    public class EnderecoRequest
    {
        [Required(ErrorMessage = "Campo obrigatorio!")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio!")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio!")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio!")]
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio!")]        
        public string Cep { get; set; }
    }
}
