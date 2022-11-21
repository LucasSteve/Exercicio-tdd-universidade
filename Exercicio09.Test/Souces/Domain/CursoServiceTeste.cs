using AutoFixture;
using Bogus;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Exceptions;
using Exercicio09.Domain.Interfaces.Repositories;
using Exercicio09.Domain.Services;
using Exercicio09.Test.Configs;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Souces.Domain
{
    public class CursoServiceTeste
    {
        private readonly Mock<ICursoRepository> _mockCursoRepository;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
        private readonly Fixture _fixture;
        private readonly Faker _faker;

        public CursoServiceTeste()
        {
            _mockCursoRepository = new Mock<ICursoRepository>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            _fixture = FixtureConfig.Get();
            _faker = new Faker();
        }

        [Theory(DisplayName = "Busca um Curso por Id")]
        [InlineData("Aluno")]
        [InlineData("Professor")]
        public async Task GetById(string perfil)
        {
            var entity = _fixture.Create<Curso>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockCursoRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Curso, bool>>>())).ReturnsAsync(entity);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var service = new CursoService(_mockCursoRepository.Object, _mockHttpContextAccessor.Object);

            var response = await service.ObterPorIdAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Theory(DisplayName = "Busca um Curso por Id não existente")]
        [InlineData("Cliente")]
        [InlineData("Tecnico")]
        public async Task GetByIdErro(string perfil)
        {
            var id = _fixture.Create<int>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockCursoRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Curso, bool>>>())).ReturnsAsync((Curso)null);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var service = new CursoService(_mockCursoRepository.Object, _mockHttpContextAccessor.Object);

            await Assert.ThrowsAnyAsync<InformacaoException>(() => service.ObterPorIdAsync(id));
        }

        [Theory(DisplayName = "Busca todos Curso")]
        [InlineData("Cliente")]
        [InlineData("Tecnico")]
        public async Task Get(string perfil)
        {
            var entities = _fixture.Create<List<Curso>>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockCursoRepository.Setup(mock => mock.ListAsync(It.IsAny<Expression<Func<Curso, bool>>>())).ReturnsAsync(entities);

            var service = new CursoService(_mockCursoRepository.Object, _mockHttpContextAccessor.Object);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var response = await service.ObterTodosAsync();

            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Cadastra um novo Curso")]
        public async Task Post()
        {
            var entity = _fixture.Create<Curso>();

            _mockCursoRepository.Setup(mock => mock.AddAsync(It.IsAny<Curso>())).Returns(Task.CompletedTask);

            var service = new CursoService(_mockCursoRepository.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.AdicionarAsync(entity));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Atualiza um Curso existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Curso>();

            _mockCursoRepository.Setup(mock => mock.FindAsNoTrackingAsync(It.IsAny<Expression<Func<Curso, bool>>>())).ReturnsAsync(entity);
            _mockCursoRepository.Setup(mock => mock.EditAsync(It.IsAny<Curso>())).Returns(Task.CompletedTask);

            var service = new CursoService(_mockCursoRepository.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.AlterarAsync(entity));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Remove um Curso existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Curso>();

            _mockCursoRepository.Setup(mock => mock.FindAsync(It.IsAny<int>())).ReturnsAsync(entity);
            _mockCursoRepository.Setup(mock => mock.RemoveAsync(It.IsAny<Curso>())).Returns(Task.CompletedTask);

            var service = new CursoService(_mockCursoRepository.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.DeletarAsync(entity.Id));
            Assert.Null(exception);
        }
    }
}
