using Bogus;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;

namespace Exercicio09.Test.Fakers
{
    public class DepartamentoFakers
    {

        private static readonly Faker faker = new Faker();

        public static Departamento DepartamentoFaker()
        {
            return new Departamento()
            {
                #region BaseEntity
                Id = faker.Random.Int(1, 10),
                Ativo = true,
                UsuarioInclusao = faker.Random.Int(1, 10),
                DataInclusao = DateTime.Now,
                UsuarioAlteracao = faker.Random.Int(1, 10),
                DataAlteracao = DateTime.Now,
                #endregion
                Endereco = EnderecoFakers.EnderecoFaker(),
                EnderecoID = faker.Random.Int(1, 10),
                Nome = faker.Name.JobTitle(),
            };
        }
        public static DepartamentoResponse DepartamentoResponseFaker()
        {
            return new DepartamentoResponse()
            {
                Id = faker.Random.Int(),
                Ativo = true,
                Endereco = EnderecoFakers.EnderecoResponseFaker(),
                Nome = faker.Name.JobTitle(),
            };
        }
        public static DepartamentoRequest DepartamentoRequestFaker()
        {
            return new DepartamentoRequest()
            {
                Endereco = EnderecoFakers.EnderecoRequestFaker(),
                Nome = faker.Name.JobTitle(),
            };
        }

        public static DepartamentoNomeRequest DepartamentoNomeRequestFaker()
        {
            return new DepartamentoNomeRequest()
            {                
                Nome = faker.Name.JobTitle(),
            };
        }
    };
}
