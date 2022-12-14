using Bogus;
using Exercicio09.Domain.Entities;

namespace Exercicio09.Test.Fakers
{
    public class BaseEntityFakers
    {
        private static readonly Faker faker = new Faker();

        public static BaseEntity BaseEntityFaker()
        {
            return new BaseEntity()
            {
                Id = faker.Random.Int(1,10),
                Ativo = true,
                UsuarioInclusao = faker.Random.Int(1, 10),
                DataInclusao = DateTime.Now,
                UsuarioAlteracao = faker.Random.Int(1, 10),
                DataAlteracao = DateTime.Now,
            };
        }
    };
}

