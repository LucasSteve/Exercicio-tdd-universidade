using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Responses
{
    public class EnderecoResponse : BaseResponse
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
    }
}
