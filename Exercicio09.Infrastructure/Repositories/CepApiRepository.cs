using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Infrastructure.Repositories
{
    public class CepApiRepository : BaseApiRepository,ICepApiRepository
    {
        public CepApiRepository(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiCep> GetPorCep(string cep)
        {
            return await GetAsync<ApiCep>($"{cep}");
        }

    }
}
