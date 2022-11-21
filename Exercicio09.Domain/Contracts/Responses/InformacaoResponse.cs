using Exercicio09.Domain.Enums;
using Exercicio09.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Responses
{
    public class InformacaoResponse
    {
        public StatusException Codigo { get; set; }
        public string Descricao { get { return Codigo.Description(); } }
        public List<string>? Mensagens { get; set; }
        public string Detalhe { get; set; }

    }
}
