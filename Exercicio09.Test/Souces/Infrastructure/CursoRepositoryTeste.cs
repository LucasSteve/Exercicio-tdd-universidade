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
    public class CursoRepositoryTeste
    {
        private readonly Mock<Exercicio09Context> _mockContext;
        private readonly Fixture _fixture;

        public CursoRepositoryTeste()
        {
            _mockContext = new Mock<Exercicio09Context>(new DbContextOptionsBuilder<Exercicio09Context>().UseLazyLoadingProxies().Options);
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Lista Cursos")]
        public async Task Get()
        {
            var entities = _fixture.Create<List<Curso>>();

            _mockContext.Setup(mock => mock.Set<Curso>()).ReturnsDbSet(entities);

            var repository = new CursoRepository(_mockContext.Object);

            var response = await repository.ListAsync();

            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Busca Curso Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Curso>();

            _mockContext.Setup(mock => mock.Set<Curso>().FindAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var repository = new CursoRepository(_mockContext.Object);

            var response = await repository.FindAsync(entity.Id);

            Assert.Equal(response.Id, entity.Id);
        }

        [Fact(DisplayName = "Cadastra Curso")]
        public async Task Post()
        {
            var entity = _fixture.Create<Curso>();

            _mockContext.Setup(mock => mock.Set<Curso>()).ReturnsDbSet(new List<Curso> { new Curso() });

            var repository = new CursoRepository(_mockContext.Object);

            try
            {
                await repository.AddAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Edita Curso Existente")]
        public async Task Put()
        {
            var entity = _fixture.Create<Curso>();

            _mockContext.Setup(mock => mock.Set<Curso>()).ReturnsDbSet(new List<Curso> { new Curso() });

            var repository = new CursoRepository(_mockContext.Object);

            try
            {
                await repository.EditAsync(entity);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact(DisplayName = "Remove Curso Existente")]
        public async Task Delete()
        {
            var entity = _fixture.Create<Curso>();

            _mockContext.Setup(mock => mock.Set<Curso>()).ReturnsDbSet(new List<Curso> { entity });

            var repository = new CursoRepository(_mockContext.Object);

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
