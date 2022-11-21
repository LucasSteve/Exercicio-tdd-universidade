using Bogus;
using Bogus.Extensions.Brazil;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;

namespace Exercicio09.Test.Fakers
{
    public class UsuarioFakers
    {
        private static readonly Faker faker = new Faker();

        public static int GetId()
        {
            return faker.Random.Int(1,10);
        }

        public static Usuario UsuarioFaker()
        {
            return new Usuario()
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
                EnderecoId = faker.Random.Int(1, 10),
                Nome = faker.Person.FirstName.ToString(),
                Email= faker.Person.Email,
                Senha = faker.Internet.Password(),
                Cpf = faker.Person.Cpf(),
                DataNascimento = faker.Person.DateOfBirth.ToLocalTime(),                
                CursoId = faker.Random.Int(1, 10),
                PerfilId = faker.Random.Int(1, 10),
                Curso = CursoFakers.CursoFaker(),
                Perfil = PerfilFakers.PerfilFaker(),
            };
        }

        public static async Task<Usuario> UsuarioFakerId(int id)
        {
            return new Usuario()
            {
                #region BaseEntity
                Id = id,
                Ativo = true,
                UsuarioInclusao = faker.Random.Int(1, 10),
                DataInclusao = DateTime.Now,
                UsuarioAlteracao = faker.Random.Int(1, 10),
                DataAlteracao = DateTime.Now,
                #endregion
                Endereco = EnderecoFakers.EnderecoFaker(),
                EnderecoId = faker.Random.Int(1, 10),
                Nome = faker.Person.FirstName.ToString(),
                Email = faker.Person.Email,
                Senha = faker.Internet.Password(),
                Cpf = faker.Person.Cpf(),
                DataNascimento = faker.Person.DateOfBirth.ToLocalTime(),                
                CursoId = faker.Random.Int(1, 10),
                PerfilId = faker.Random.Int(1, 10),
                Curso = CursoFakers.CursoFaker(),
                Perfil = PerfilFakers.PerfilFaker(),
            };
        }

        public static UsuarioResponse UsuarioResponseFaker()
        {
            return new UsuarioResponse()
            {
                Nome = faker.Person.FirstName.ToString(),                
                Cpf = faker.Person.Cpf(),
                Perfil = PerfilFakers.PerfilResponseFaker(),
                DataNascimento = faker.Person.DateOfBirth.ToLocalTime(),
                CursoId = faker.Random.Int(1, 10),
                Endereco = EnderecoFakers.EnderecoResponseFaker(),
                Id = faker.Random.Int(1, 10),
                Ativo = true,
            };
        }

        public static async Task<UsuarioResponse> UsuarioResponseFakerId(int id)
        {
            return new UsuarioResponse()
            {
                Nome = faker.Person.FirstName.ToString(),
                Cpf = faker.Person.Cpf(),
                Perfil = PerfilFakers.PerfilResponseFaker(),
                DataNascimento = faker.Person.DateOfBirth.ToLocalTime(),
                CursoId = faker.Random.Int(1, 10),
                Endereco = EnderecoFakers.EnderecoResponseFaker(),
                Id = id,
                Ativo = true,
            };
        }

        public static UsuarioRequest UsuarioRequestFaker()
        {
            return new UsuarioRequest()
            {
                Nome = faker.Person.FirstName.ToString(),
                Senha = faker.Internet.Password(),
                Cpf = faker.Person.Cpf(),
                PerfilId = faker.Random.Int(1, 10),
                DataNascimento = faker.Person.DateOfBirth.ToLocalTime(),
                CursoId = faker.Random.Int(1, 10),
                Endereco = EnderecoFakers.EnderecoRequestFaker(),
            };
        }

        public static UsuarioCpfRequest UsuarioCpfRequestFaker()
        {
            return new UsuarioCpfRequest()
            {
               
                Cpf = faker.Person.Cpf(),
               
            };
        }
    }
}
