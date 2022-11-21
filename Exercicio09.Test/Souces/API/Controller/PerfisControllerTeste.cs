using AutoFixture;
using AutoMapper;
using Exercicio09.Api.Controllers;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Services;
using Exercicio09.Test.Configs;
using Exercicio09.Test.Fakers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Souces.API.Controller
{
    [Trait("Controller", "Controller Perfis")]
    public class PerfisControllerTeste
    {
        private readonly Mock<IPerfilService> _mockPerfilService;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;

        public PerfisControllerTeste()
        {
            _mockPerfilService = new Mock<IPerfilService>();
            _mapper = MapConfig.Get();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Lista Perfis")]
        public async Task GetAsync()
        {
            var entities = _fixture.Create<List<Perfil>>();

            _mockPerfilService.Setup(mock => mock.ObterTodosAsync()).ReturnsAsync(entities);

            var controller = new PerfisController(_mapper, _mockPerfilService.Object);

            var actionResult = await controller.GetAsync();

            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var response = Assert.IsType<List<PerfilResponse>>(objectResult.Value);
            Assert.True(response.Count() > 0);
        }

        [Fact(DisplayName = "Busca Perfil Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Perfil>();

            _mockPerfilService.Setup(mock => mock.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var controller = new PerfisController(_mapper, _mockPerfilService.Object);

            var actionResult = await controller.GetByIdAsync(entity.Id);

            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var response = Assert.IsType<PerfilResponse>(objectResult.Value);
            Assert.Equal(response.Id, entity.Id);
        }

        [Fact(DisplayName = "Cadastra Perfil")]
        public async Task Post()
        {
            var request = _fixture.Create<PerfilRequest>();

            _mockPerfilService.Setup(mock => mock.AdicionarAsync(It.IsAny<Perfil>())).Returns(Task.CompletedTask);

            var controller = new PerfisController(_mapper, _mockPerfilService.Object);

            var actionResult = await controller.PostAsync(request);

            var objectResult = Assert.IsType<CreatedResult>(actionResult);
            Assert.Equal(StatusCodes.Status201Created, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Edita Perfil Existente")]
        public async Task Put()
        {
            var id = _fixture.Create<int>();
            var request = _fixture.Create<PerfilRequest>();

            _mockPerfilService.Setup(mock => mock.AlterarAsync(It.IsAny<Perfil>())).Returns(Task.CompletedTask);

            var controller = new PerfisController(_mapper, _mockPerfilService.Object);

            var actionResult = await controller.PutAsync(id, request);

            var objectResult = Assert.IsType<NoContentResult>(actionResult);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Remove Perfil Existente")]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _mockPerfilService.Setup(mock => mock.DeletarAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var controller = new PerfisController(_mapper, _mockPerfilService.Object);

            var actionResult = await controller.DeleteAsync(id);

            var objectResult = Assert.IsType<NoContentResult>(actionResult);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }


        [Fact(DisplayName = "Atualiza um nome de departamento existente")]
        public async Task AlterarNomePerfil()
        {
            var id = _fixture.Create<int>();
            var request = PerfilFakers.PerfilRequestFaker();
            var nomeRequest = _fixture.Create<string>();

            _mockPerfilService.Setup(mock => mock.AtualizarNomeAsync(id, nomeRequest)).Returns(Task.CompletedTask);

            var controller = new PerfisController(_mapper, _mockPerfilService.Object);

            var response = await controller.PatchAsync(id, request);

            var objectResult = Assert.IsType<OkResult>(response);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }

    }
}
