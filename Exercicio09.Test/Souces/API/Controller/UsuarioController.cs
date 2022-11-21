using AutoFixture;
using AutoMapper;
using Exercicio09.Api.Controllers;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Services;
using Exercicio09.Test.Configs;
using Exercicio09.Test.Fakers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Exercicio09.Test.Sources.API.Controller
{
    [Trait("Controller", "Usuario Controller")]
    public class UsuarioControllerTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;
        public UsuarioControllerTest()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _mapper = MapConfig.Get();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Busca um usuário por Id")]
        public async Task GetById()
        {
            var entity = _fixture.Create<Usuario>();

            _mockUsuarioService.Setup(mock => mock.ObterPorIdUsuarioAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var controller = new UsuariosController(_mapper, _mockUsuarioService.Object);

            var response = await controller.GetByIdAsync(entity.Id);

            var objectResult = Assert.IsType<OkObjectResult>(response.Result);
            var usuarioResponse = Assert.IsType<UsuarioResponse>(objectResult.Value);
            Assert.Equal(usuarioResponse.Id, entity.Id);
        }

        [Fact(DisplayName = "Busca todos usuários")]
        public async Task Get()
        {
            var entities = _fixture.Create<List<Usuario>>();

            _mockUsuarioService.Setup(mock => mock.ObterTodosAsync()).ReturnsAsync(entities);

            var controller = new UsuariosController(_mapper, _mockUsuarioService.Object);

            var response = await controller.GetAsync();

            var objectResult = Assert.IsType<OkObjectResult>(response.Result);
            var usuarioResponse = Assert.IsType<List<UsuarioResponse>>(objectResult.Value);
            Assert.True(usuarioResponse.Count() > 0);
        }

        [Fact(DisplayName = "Cadastra uma novo usuário")]
        public async Task Post()
        {
            var request = UsuarioFakers.UsuarioRequestFaker();

            _mockUsuarioService.Setup(mock => mock.AdicionarAsync(It.IsAny<Usuario>())).Returns(Task.CompletedTask);

            var controller = new UsuariosController(_mapper, _mockUsuarioService.Object);

            var response = await controller.PostAsync(request);

            var objectResult = Assert.IsType<CreatedResult>(response);
            Assert.Equal(StatusCodes.Status201Created, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Atualiza uma usuário existente")]
        public async Task Put()
        {
            var id = _fixture.Create<int>();
            var request = Fakers.UsuarioFakers.UsuarioRequestFaker();

            _mockUsuarioService.Setup(mock => mock.AlterarAsync(It.IsAny<Usuario>())).Returns(Task.CompletedTask);

            var controller = new UsuariosController(_mapper, _mockUsuarioService.Object);

            var response = await controller.PutAsync(id, request);

            var objectResult = Assert.IsType<NoContentResult>(response);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Remove uma usuário existente")]
        public async Task Delete()
        {
            var id = _fixture.Create<int>();

            _mockUsuarioService.Setup(mock => mock.DeletarAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            var controller = new UsuariosController(_mapper, _mockUsuarioService.Object);

            var response = await controller.DeleteAsync(id);

            var objectResult = Assert.IsType<NoContentResult>(response);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);
        }

        [Fact(DisplayName = "Atualiza o Cpf de um usuario existente")]
        public async Task AlterarNomePerfil()
        {
            var id = _fixture.Create<int>();
            var request = UsuarioFakers.UsuarioCpfRequestFaker();
            var cpfRequest = _fixture.Create<string>();

            _mockUsuarioService.Setup(mock => mock.AtualizarCpfAsync(id, cpfRequest)).Returns(Task.CompletedTask);

            var controller = new UsuariosController(_mapper, _mockUsuarioService.Object);

            var response = await controller.PatchAsync(id, request);

            var objectResult = Assert.IsType<OkResult>(response);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }
    }
}
