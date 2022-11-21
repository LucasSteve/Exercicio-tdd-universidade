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
    public class PerfilRepositoryTeste
    {
        private readonly Mock<Exercicio09Context> _mockContext;
        private readonly Fixture _fixture;

        public PerfilRepositoryTeste()
        {
            _mockContext = new Mock<Exercicio09Context>(new DbContextOptionsBuilder<Exercicio09Context>().UseLazyLoadingProxies().Options);
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Lista Perfis")]
        public async Task Get()
        {
            var entities = _fixture.Create<List<Perfil>>();

            _mockContext.Setup(mock => mock.Set<Perfil>()).ReturnsDbSet(entities);

            var repository = new PerfilRepository(_mockContext.Object);

            var response = await repository.ListAsync();

            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Busca Perfi Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Perfil>();

            _mockContext.Setup(mock => mock.Set<Perfil>().FindAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var repository = new PerfilRepository(_mockContext.Object);

            var response = await repository.FindAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Fact(DisplayName = "Cadastra Perfil")]
        public async Task Post()
        {
            var entity = _fixture.Create<Perfil>();

            _mockContext.Setup(mock => mock.Set<Perfil>()).ReturnsDbSet(new List<Perfil> { new Perfil() });

            var repository = new PerfilRepository(_mockContext.Object);

            try
            {
                await repository.AddAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Perfil Existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Perfil>();

            _mockContext.Setup(mock => mock.Set<Perfil>()).ReturnsDbSet(new List<Perfil> { new Perfil() });

            var repository = new PerfilRepository(_mockContext.Object);

            try
            {
                await repository.EditAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Remove Perfil Existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Perfil>();

            _mockContext.Setup(mock => mock.Set<Perfil>()).ReturnsDbSet(new List<Perfil> { entity });

            var repository = new PerfilRepository(_mockContext.Object);

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
