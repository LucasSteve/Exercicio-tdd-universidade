using Bogus;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;

namespace Exercicio09.Test.Fakers
{
    public class EnderecoFakers
    {
        private static readonly Faker faker = new Faker();

        public static Endereco EnderecoFaker()
        {
            return new Endereco()
            {
                #region BaseEntity
                Id = faker.Random.Int(1, 10),
                Ativo = true,
                UsuarioInclusao = faker.Random.Int(1, 10),
                DataInclusao = DateTime.Now,
                UsuarioAlteracao = faker.Random.Int(1, 10),
                DataAlteracao = DateTime.Now,
                #endregion
                Cep = faker.Address.ZipCode("#####-###"),
                Cidade = faker.Address.City(),
                Estado = faker.Address.Country(),
                Rua = faker.Address.StreetName(),
            };
        }
        public static EnderecoResponse EnderecoResponseFaker()
        {
            return new EnderecoResponse()
            {
                Id = faker.Random.Int(),
                Ativo = true,
                Cep = faker.Address.ZipCode("#####-###"),
                Cidade = faker.Address.City(),
                Estado = faker.Address.Country(),
                Rua = faker.Address.StreetName(),
            };
        }
        public static EnderecoRequest EnderecoRequestFaker()
        {
            return new EnderecoRequest()
            {
                Cep = faker.Address.ZipCode("#####-###"),
                Cidade = faker.Address.City(),
                Estado = faker.Address.Country(),
                Rua = faker.Address.StreetName(),
            };
        }
    };
}
