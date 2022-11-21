using AutoFixture;
using Exercicio09.Domain.Entities;
using Exercicio09.Infrastructure.Contexts;
using Exercicio09.Infrastructure.Repositories;
using Exercicio09.Test.Configs;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Souces.Infrastructure
{
    public class EnderecoRepositoryTeste
    {

        private readonly Mock<Exercicio09Context> _mockContext;
        private readonly Fixture _fixture;

        public EnderecoRepositoryTeste()
        {
            _mockContext = new Mock<Exercicio09Context>(new DbContextOptionsBuilder<Exercicio09Context>().UseLazyLoadingProxies().Options);
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Lista Enderecos")]
        public async Task Get()
        {
            var entities = _fixture.Create<List<Endereco>>();

            _mockContext.Setup(mock => mock.Set<Endereco>()).ReturnsDbSet(entities);

            var repository = new EnderecoRepository(_mockContext.Object);

            var response = await repository.ListAsync();

            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Busca Endereco Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Endereco>();

            _mockContext.Setup(mock => mock.Set<Endereco>().FindAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var repository = new EnderecoRepository(_mockContext.Object);

            var response = await repository.FindAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Fact(DisplayName = "Cadastra Endereco")]
        public async Task Post()
        {
            var entity = _fixture.Create<Endereco>();

            _mockContext.Setup(mock => mock.Set<Endereco>()).ReturnsDbSet(new List<Endereco> { new Endereco() });

            var repository = new EnderecoRepository(_mockContext.Object);

            try
            {
                await repository.AddAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Endereco Existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Endereco>();

            _mockContext.Setup(mock => mock.Set<Endereco>()).ReturnsDbSet(new List<Endereco> { new Endereco() });

            var repository = new EnderecoRepository(_mockContext.Object);

            try
            {
                await repository.EditAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Remove Endereco Existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Endereco>();

            _mockContext.Setup(mock => mock.Set<Endereco>()).ReturnsDbSet(new List<Endereco> { entity });

            var repository = new EnderecoRepository(_mockContext.Object);

            try
            {
                await repository.RemoveAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }
}
