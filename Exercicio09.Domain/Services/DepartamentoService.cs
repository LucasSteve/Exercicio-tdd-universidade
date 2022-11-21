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
    public class DepartamentoService : BaseService<Departamento>, IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public DepartamentoService(IDepartamentoRepository departamentoRepository, IHttpContextAccessor httpContextAccessor) : base(departamentoRepository, httpContextAccessor)
        {
            _departamentoRepository= departamentoRepository;
        }

        public async Task AtualizarNomeAsync(int id,string nome)
        {
            var entity = await ObterPorIdAsync(id);
            entity.Nome = nome;
            entity.DataAlteracao = DateTime.Now;
            entity.UsuarioAlteracao = UserId;
            await _departamentoRepository.EditAsync(entity);
        }

    }
}
