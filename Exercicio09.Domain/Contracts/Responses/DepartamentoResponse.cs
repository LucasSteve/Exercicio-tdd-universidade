using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Responses
{
    public class DepartamentoResponse : BaseResponse
    {
        public string Nome { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}
