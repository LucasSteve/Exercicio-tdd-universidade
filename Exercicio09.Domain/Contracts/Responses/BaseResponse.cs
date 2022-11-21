using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Responses
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
    }
}
