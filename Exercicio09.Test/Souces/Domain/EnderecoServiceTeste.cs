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


namespace Exercicio09.Test.Souces.Domain
{
    public class EnderecoServiceTeste
    {
        private readonly Mock<IEnderecoRepository> _mockEnderecoRepository;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
        private readonly Mock<ICepApiRepository> _mockApiAcessor;
        private readonly Fixture _fixture;
        private readonly Faker _faker;

        public EnderecoServiceTeste()
        {
            _mockEnderecoRepository = new Mock<IEnderecoRepository>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            _mockApiAcessor =new Mock<ICepApiRepository>();
            _fixture = FixtureConfig.Get();
            _faker = new Faker();
        }

        [Theory(DisplayName = "Busca um Endereco por Id")]
        [InlineData("Aluno")]
        [InlineData("Professor")]
        public async Task GetById(string perfil)
        {
            var entity = _fixture.Create<Endereco>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockEnderecoRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Endereco, bool>>>())).ReturnsAsync(entity);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var service = new EnderecoService(_mockEnderecoRepository.Object,_mockApiAcessor.Object ,_mockHttpContextAccessor.Object);

            var response = await service.ObterPorIdAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Theory(DisplayName = "Busca um Endereco por Id não existente")]
        [InlineData("Cliente")]
        [InlineData("Tecnico")]
        public async Task GetByIdErro(string perfil)
        {
            var id = _fixture.Create<int>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockEnderecoRepository.Setup(mock => mock.FindAsync(It.IsAny<Expression<Func<Endereco, bool>>>())).ReturnsAsync((Endereco)null);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var service = new EnderecoService(_mockEnderecoRepository.Object, _mockApiAcessor.Object, _mockHttpContextAccessor.Object);

            await Assert.ThrowsAnyAsync<InformacaoException>(() => service.ObterPorIdAsync(id));
        }

        [Theory(DisplayName = "Busca todos Endereco")]
        [InlineData("Cliente")]
        [InlineData("Tecnico")]
        public async Task Get(string perfil)
        {
            var entities = _fixture.Create<List<Endereco>>();
            var claims = ClaimConfig.Get(_faker.UniqueIndex, _faker.Person.FullName, _faker.Person.Email, perfil);

            _mockEnderecoRepository.Setup(mock => mock.ListAsync(It.IsAny<Expression<Func<Endereco, bool>>>())).ReturnsAsync(entities);

            var service = new EnderecoService(_mockEnderecoRepository.Object, _mockApiAcessor.Object, _mockHttpContextAccessor.Object);
            _mockHttpContextAccessor.Setup(mock => mock.HttpContext.User.Claims).Returns(claims);

            var response = await service.ObterTodosAsync();

            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Cadastra um novo Endereco")]
        public async Task Post()
        {
            var entity = _fixture.Create<Endereco>();

            _mockEnderecoRepository.Setup(mock => mock.AddAsync(It.IsAny<Endereco>())).Returns(Task.CompletedTask);

            var service = new EnderecoService(_mockEnderecoRepository.Object, _mockApiAcessor.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.AdicionarAsync(entity));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Atualiza um Endereco existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Endereco>();

            _mockEnderecoRepository.Setup(mock => mock.FindAsNoTrackingAsync(It.IsAny<Expression<Func<Endereco, bool>>>())).ReturnsAsync(entity);
            _mockEnderecoRepository.Setup(mock => mock.EditAsync(It.IsAny<Endereco>())).Returns(Task.CompletedTask);

            var service = new EnderecoService(_mockEnderecoRepository.Object, _mockApiAcessor.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.AlterarAsync(entity));
            Assert.Null(exception);
        }

        [Fact(DisplayName = "Remove um Endereco existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Endereco>();

            _mockEnderecoRepository.Setup(mock => mock.FindAsync(It.IsAny<int>())).ReturnsAsync(entity);
            _mockEnderecoRepository.Setup(mock => mock.RemoveAsync(It.IsAny<Endereco>())).Returns(Task.CompletedTask);

            var service = new EnderecoService(_mockEnderecoRepository.Object, _mockApiAcessor.Object, _mockHttpContextAccessor.Object);

            var exception = await Record.ExceptionAsync(() => service.DeletarAsync(entity.Id));
            Assert.Null(exception);
        } 
    }
}

