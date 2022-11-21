using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Entities
{
    public class Departamento : BaseEntity
    {
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
