using Exercicio09.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Interfaces.Services
{
    public interface IEnderecoService : IBaseService<Endereco>
    {
        Task<ApiCep> GetPorCep(string cep);
    }
}
