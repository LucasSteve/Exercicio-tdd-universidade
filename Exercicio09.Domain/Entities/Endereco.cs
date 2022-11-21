using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
