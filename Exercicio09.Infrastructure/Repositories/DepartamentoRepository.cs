using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Repositories;
using Exercicio09.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Infrastructure.Repositories
{
    public class DepartamentoRepository : BaseRepository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(Exercicio09Context context) : base(context)
        {
        }
    }
}
