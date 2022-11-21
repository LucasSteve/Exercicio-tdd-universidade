using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Enums;
using Exercicio09.Domain.Interfaces.Repositories;
using Exercicio09.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Services
{
    public class CursoService : BaseService<Curso>, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository,IHttpContextAccessor httpContextAccessor) : base(cursoRepository, httpContextAccessor)
        {
            _cursoRepository = cursoRepository;
        }



        public async Task AtualizarTurnoAsync(int id, Turno turno)
        {
            var entity = await ObterPorIdAsync(id);
            entity.Turno = turno;
            entity.DataAlteracao = DateTime.Now;
            entity.UsuarioAlteracao = UserId;
            await _cursoRepository.EditAsync(entity);
        }

    }
}
