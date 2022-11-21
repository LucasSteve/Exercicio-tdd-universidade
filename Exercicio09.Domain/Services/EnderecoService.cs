using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Repositories;
using Exercicio09.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Services
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        private readonly ICepApiRepository _cepApiRepository;
        public EnderecoService(IEnderecoRepository repository, ICepApiRepository cepApiRepository, IHttpContextAccessor httpContextAccessor) : base(repository, httpContextAccessor)
        {
            _cepApiRepository = cepApiRepository;
        }

        public async Task<ApiCep> GetPorCep(string cep) 
        {
            return await _cepApiRepository.GetPorCep(cep);
        }
    }
}
