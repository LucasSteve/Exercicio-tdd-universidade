using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Requests
{
    public class UsuarioRequest
    {
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio.")]        
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio.")]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }      
        
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio.")]        
        [DataType(DataType.Password)]

        public string Senha { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public EnderecoRequest Endereco { get; set; }        
       
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public int CursoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public int PerfilId { get; set; }
    }
}
