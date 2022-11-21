using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Responses
{
    public class UsuarioResponse : BaseResponse
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }       
        public EnderecoResponse Endereco { get; set; }
        public PerfilResponse Perfil { get; set; }
        public CursoResponse Curso { get; set; }
        public string Cpf { get; set; }
        public int CursoId { get; set; }
        

    }
}
