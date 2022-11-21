using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Enums;
using Exercicio09.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Interfaces.Services
{
    public interface ICursoService : IBaseService<Curso>
    {
        Task AtualizarTurnoAsync(int id, Turno turno);


    }
}
