using AutoFixture;
using Exercicio09.Domain.Entities;
using Exercicio09.Infrastructure.Contexts;
using Exercicio09.Infrastructure.Repositories;
using Exercicio09.Test.Configs;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace Exercicio09.Test.Souces.Infrastructure
{
    [Trait("Repository", "Repository Usuario")]
    public class UsuarioRepositoryTeste
    {
        private readonly Mock<Exercicio09Context> _mockContext;
        private readonly Fixture _fixture;

        public UsuarioRepositoryTeste()
        {
            _mockContext = new Mock<Exercicio09Context>(new DbContextOptionsBuilder<Exercicio09Context>().UseLazyLoadingProxies().Options);
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Lista Usuarios")]
        public async Task Get()
        {
            var entities = _fixture.Create<List<Usuario>>();

            _mockContext.Setup(mock => mock.Set<Usuario>()).ReturnsDbSet(entities);

            var repository = new UsuarioRepository(_mockContext.Object);

            var response = await repository.ListAsync();

            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Busca Usuario Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Usuario>();

            _mockContext.Setup(mock => mock.Set<Usuario>().FindAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var repository = new UsuarioRepository(_mockContext.Object);

            var response = await repository.FindAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Fact(DisplayName = "Cadastra Usuario")]
        public async Task Post()
        {
            var entity = _fixture.Create<Usuario>();

            _mockContext.Setup(mock => mock.Set<Usuario>()).ReturnsDbSet(new List<Usuario> { new Usuario() });

            var repository = new UsuarioRepository(_mockContext.Object);

            try
            {
                await repository.AddAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Usuario Existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Usuario>();

            _mockContext.Setup(mock => mock.Set<Usuario>()).ReturnsDbSet(new List<Usuario> { new Usuario() });

            var repository = new UsuarioRepository(_mockContext.Object);

            try
            {
                await repository.EditAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Remove Usuario Existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Usuario>();

            _mockContext.Setup(mock => mock.Set<Usuario>()).ReturnsDbSet(new List<Usuario> { entity });

            var repository = new UsuarioRepository(_mockContext.Object);

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
