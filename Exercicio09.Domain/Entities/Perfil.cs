using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Entities
{
    public class Perfil : BaseEntity
    {
        public string Nome { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }


    }
}
