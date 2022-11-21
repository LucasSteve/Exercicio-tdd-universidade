using AutoFixture;
using Bogus;
using Exercicio09.Domain.Exceptions;
using Exercicio09.Test.Configs;
using Moq.Protected;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Exercicio09.Domain.Entities;
using Exercicio09.Infrastructure.Repositories;

namespace Exercicio09.Test.Souces.Infrastructure
{
    public class CepApiRepositoryTeste
    {
        private readonly Fixture _fixture;
        private readonly Faker _faker;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public CepApiRepositoryTeste()
        {
            _fixture = FixtureConfig.Get();
            _faker = new Faker();
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        }

        [Fact(DisplayName = "Buscar endereco pelo cep")]
        public async Task GetByCep()
        {
            var entity = _fixture.Create<Endereco>();

            var httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = JsonContent.Create(entity)
            };

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            var url = _faker.Internet.Url();

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(url)
            };

            var repository = new CepApiRepository(httpClient);

            var response = await repository.GetPorCep(entity.Cep);

            Assert.Equal(response.Cep, entity.Cep);
        }

        [Fact(DisplayName = "Buscar endereco pelo cep com erro 500")]
        public async Task GetByCepErro500()
        {
            var cep = _faker.Address.ZipCode();

            var httpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Content = JsonContent.Create("Erro ao fazer a consulta.")
            };

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponseMessage);

            var url = _faker.Internet.Url();

            var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(url)
            };

            var repository = new CepApiRepository(httpClient);

            await Assert.ThrowsAnyAsync<InformacaoException>(() => repository.GetPorCep(cep));
        }

    }
}
