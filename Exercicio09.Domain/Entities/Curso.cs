using Exercicio09.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Entities
{
    public class Curso : BaseEntity
    {
        public string Nome { get; set; }        
        public Turno Turno { get; set; }       
        public int DepartamentoId { get; set; }
        public  virtual Departamento Departamento { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }  
    }
}
