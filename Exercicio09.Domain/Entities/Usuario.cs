using Exercicio09.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }              
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Curso Curso { get; set; }
        public int CursoId { get; set; } 
        public int PerfilId { get; set; }

      
    }
}
