using AutoFixture;
using AutoMapper;
using Exercicio09.Api.Controllers;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Interfaces.Services;
using Exercicio09.Test.Configs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Souces.API.Controller
{
    [Trait("Controller", "Controller Autenticação")]
    public class AutenticacoesControllerTeste
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;

        public AutenticacoesControllerTeste()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _mapper = MapConfig.Get();
            _fixture = FixtureConfig.Get();
        }

        [Fact(DisplayName = "Cria Token")]
        public async Task Post()
        {
            var request = _fixture.Create<AutenticacaoRequest>();
            var response = _fixture.Create<AutenticacaoResponse>();

            _mockUsuarioService.Setup(mock => mock.AutenticarAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(response);

            var controller = new AutenticacoesController(_mockUsuarioService.Object);

            var actionResult = await controller.PostAsync(request);

            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var responseResult = Assert.IsType<AutenticacaoResponse>(objectResult.Value);
            Assert.Equal(responseResult.Token, response.Token);
        }

    }
}
