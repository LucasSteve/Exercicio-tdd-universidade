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
    public class DepartamentoServiceTeste
    {

        private readonly Mock<IDepartamentoRepository> _mockDepartamentoRepository;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;        
        private readonly Fixture _fixture;
        private readonly Faker _faker;

        public DepartamentoServiceTeste()
        {
            _mockDepartamentoRepository = new Mock<IDepartamentoRepository>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();            
            _fixture = FixtureConfig.Get();
            _faker = new Faker();
        }

        [Theory(DisplayName = "Busca um Departamento por Id")]
        [InlineData("Aluno")]
        [InlineData("Professor")]
        public async Task GetById(string perfil)
        {
            var entity = _fixture.Create<Departamento>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockDepartamentoRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Departamento, bool>>>())).ReturnsAsync(entity);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var service = new DepartamentoService(_mockDepartamentoRepository.Object, _mockHttpContextAccessor.Object);

            var response = await service.ObterPorIdAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Theory(DisplayName = "Busca um Departamento por Id não existente")]
        [InlineData("Cliente")]
        [InlineData("Tecnico")]
        public async Task GetByIdErro(string perfil)
        {
            var id = _fixture.Create<int>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockDepartamentoRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Departamento, bool>>>())).ReturnsAsync((Departamento)null);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var service = new DepartamentoService(_mockDepartamentoRepository.Object, _mockHttpContextAccessor.Object);

            await Assert.ThrowsAnyAsync<InformacaoException>(() => service.ObterPorIdAsync(id));
        }

        [Theory(DisplayName = "Busca todos Departamento")]
        [InlineData("Cliente")]
        [InlineData("Tecnico")]
        public async Task Get(string perfil)
        {
            var entities = _fixture.Create<List<Departamento>>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockDepartamentoRepository.Setup(mock => mock.ListAsync(It.IsAny<Expression<Func<Departamento, bool>>>())).ReturnsAsync(entities);

            var service = new DepartamentoService(_mockDepartamentoRepository.Object,  _mockHttpContextAccessor.Object);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var response = await service.ObterTodosAsync();

            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Cadastra um novo Departamento")]
        public async Task Post()
        {
            var entity = _fixture.Create<Departamento>();

            _mockDepartamentoRepository.Setup(mock => mock.AddAsync(It.IsAny<Departamento>())).Returns(Task.CompletedTask);

            var service = new DepartamentoService(_mockDepartamentoRepository.Object,  _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.AdicionarAsync(entity));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Atualiza um Departamento existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Departamento>();

            _mockDepartamentoRepository.Setup(mock => mock.FindAsNoTrackingAsync(It.IsAny<Expression<Func<Departamento, bool>>>())).ReturnsAsync(entity);
            _mockDepartamentoRepository.Setup(mock => mock.EditAsync(It.IsAny<Departamento>())).Returns(Task.CompletedTask);

            var service = new DepartamentoService(_mockDepartamentoRepository.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.AlterarAsync(entity));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Remove um Departamento existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Departamento>();

            _mockDepartamentoRepository.Setup(mock => mock.FindAsync(It.IsAny<int>())).ReturnsAsync(entity);
            _mockDepartamentoRepository.Setup(mock => mock.RemoveAsync(It.IsAny<Departamento>())).Returns(Task.CompletedTask);

            var service = new DepartamentoService(_mockDepartamentoRepository.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.DeletarAsync(entity.Id));
            Assert.Null(exception);
        }
    }
}
