using Bogus;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Fakers
{
    public class PerfilFakers
    {

        private static readonly Faker faker = new Faker();

        public static Perfil PerfilFaker()
        {
            return new Perfil()
            {
                #region BaseEntity
                Id = faker.Random.Int(1, 10),
                Ativo = true,
                UsuarioInclusao = faker.Random.Int(1, 10),
                DataInclusao = DateTime.Now,
                UsuarioAlteracao = faker.Random.Int(1, 10),
                DataAlteracao = DateTime.Now,
                #endregion
                Nome = faker.Person.LastName.ToString()
            };
        }
        public static PerfilResponse PerfilResponseFaker()
        {
            return new PerfilResponse()
            {
                Id = faker.Random.Int(1, 10),
                Ativo = true,
                Nome = faker.Person.LastName.ToString(),                
            };
        }
        public static PerfilRequest PerfilRequestFaker()
        {
            return new PerfilRequest()
            {
                Nome = faker.Person.LastName.ToString()
            };
        }
     
    }
}
