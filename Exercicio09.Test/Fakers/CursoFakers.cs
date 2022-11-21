using Bogus;
using Exercicio09.Api.Controllers;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio09.Test.Fakers
{
    public class CursoFakers
    {

        private static readonly Faker faker = new Faker();

        public static Curso CursoFaker()
        {
            return new Curso()
            {
                #region BaseEntity
                Id = faker.Random.Int(1, 10),
                Ativo = true,
                UsuarioInclusao = faker.Random.Int(1, 10),
                DataInclusao = DateTime.Now,
                UsuarioAlteracao = faker.Random.Int(1, 10),
                DataAlteracao = DateTime.Now,
                #endregion
                Departamento = DepartamentoFakers.DepartamentoFaker(),
                DepartamentoId = faker.Random.Int(1, 10),
                Turno = Turno.Noturno,
                Nome = faker.Person.LastName.ToString(),
                Usuarios = new[] {UsuarioFakers.UsuarioFaker()}
            };
        }
        public static CursoResponse CursoResponseFaker()
        {
            return new CursoResponse()
            {
                Id = faker.Random.Int(),
                Ativo = true,                 
                Nome = faker.Person.FirstName.ToString(),
                Turno = Turno.Vespertino
            };
        }
        public static CursoRequest CursoRequestFaker()
        {
            return new CursoRequest()
            {
              DepartamentoId = faker.Random.Int(1,10),
              Nome= faker.Person.FirstName.ToString(),
              Turno= Turno.Matutino,
            };
        }

        public static CursoTurnoRequest CursoTurnoRequestFaker()
        {
            return new CursoTurnoRequest()
            {                
                Turno = Turno.Matutino,
            };
        }

    };
}
