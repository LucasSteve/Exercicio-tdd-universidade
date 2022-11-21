using Exercicio09.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Responses
{
    public class CursoResponse : BaseResponse
    {
        public string Nome { get; set; }        
        public Turno Turno { get; set; }      
        public DepartamentoResponse Departamento { get; set; }
    }
}
