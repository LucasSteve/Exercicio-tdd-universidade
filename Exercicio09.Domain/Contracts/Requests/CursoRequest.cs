using Exercicio09.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Requests
{
    public class CursoRequest
    {
        [Required(ErrorMessage = "Nome do curso é obrigatório.")]
        public string Nome { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [Required(ErrorMessage = "Turno do curso é obrigatorio")]
        public Turno Turno { get; set; }               
        [Required(ErrorMessage = "Id do departamento é obrigatório.")]
        public int DepartamentoId { get; set; }
    }
}
