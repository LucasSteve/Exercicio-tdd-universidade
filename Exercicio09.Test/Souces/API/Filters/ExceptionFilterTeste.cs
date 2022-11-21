using AutoFixture;
using Exercicio09.Domain.Enums;
using Exercicio09.Domain.Exceptions;
using Exercicio09.Test.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio09.Api.Filters;
using Microsoft.AspNetCore.Routing;

namespace Exercicio09.Test.Souces.API.Filters
{
    public class ExceptionFilterTeste
    {
        public class ExceptionFilterTest
        {
            private readonly Fixture _fixture;
            private readonly ActionContext _actionContext;
            private readonly List<IFilterMetadata> _filterMetadata;

            public ExceptionFilterTest()
            {
                _fixture = FixtureConfig.Get();
                _actionContext = new ActionContext
                {
                    ActionDescriptor = new ActionDescriptor(),
                    HttpContext = new DefaultHttpContext(),
                    RouteData = new RouteData()
                };
                _filterMetadata = new List<IFilterMetadata>();
            }

            [Fact(DisplayName = "Acionar uma Informacao Excepton")]
            public async void OnExceptionInformacaoException()
            {
                var exceptionContext = new ExceptionContext(_actionContext, _filterMetadata)
                {
                    Exception = new InformacaoException(StatusException.NaoEncontrado, "Nenhum dado encontrado.")
                };

                var exceptionFilter = new ExeptionFilter();

                var result = await Record.ExceptionAsync(() => exceptionFilter.OnExceptionAsync(exceptionContext));
                Assert.Null(result);
            }

            [Fact(DisplayName = "Acionar uma Informacao Excepton")]
            public async void OnExceptionIsException()
            {
                var exceptionContext = new ExceptionContext(_actionContext, _filterMetadata)
                {
                    Exception = new Exception("Erro inesperado.")
                };

                var exceptionFilter = new ExeptionFilter();

                var result = await Record.ExceptionAsync(() => exceptionFilter.OnExceptionAsync(exceptionContext));
                Assert.Null(result);
            }

            [Fact(DisplayName = "Informacao Exception Inner Exception")]
            public async Task OnExceptionFilterInformacaoExceptionInnerException()
            {
                var actionContext = new ActionContext()
                {
                    HttpContext = new DefaultHttpContext(),
                    RouteData = new RouteData(),
                    ActionDescriptor = new ActionDescriptor()
                };

                var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
                {
                    Exception = new InformacaoException(StatusException.NaoEncontrado, "Nenhum dado encontrado", new Exception("Erro Inner Exception"))
                };
                var exception = new ExeptionFilter();

                var result = await Record.ExceptionAsync(() => exception.OnExceptionAsync(exceptionContext));
                Assert.Null(result);
            }

            [Fact(DisplayName = "Exception Inner Exception")]
            public async Task OnExceptionFilterInnerException()
            {
                var actionContext = new ActionContext()
                {
                    HttpContext = new DefaultHttpContext(),
                    RouteData = new RouteData(),
                    ActionDescriptor = new ActionDescriptor()
                };

                var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
                {
                    Exception = new Exception("Erro genérico", new Exception("Erro Inner Exception"))
                };
                var exception = new ExeptionFilter();

                var result = await Record.ExceptionAsync(() => exception.OnExceptionAsync(exceptionContext));
                Assert.Null(result);
            }

            [Fact(DisplayName = "InformacaoException null")]
            public async Task OnExceptionFilterInformacaoExceptionNull()
            {
                var actionContext = new ActionContext()
                {
                    HttpContext = new DefaultHttpContext(),
                    RouteData = new RouteData(),
                    ActionDescriptor = new ActionDescriptor()
                };

                var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
                {
                    Exception = new InformacaoException(StatusException.NaoEncontrado, new List<string>())
                };
                var exception = new ExeptionFilter();

                var result = await Record.ExceptionAsync(() => exception.OnExceptionAsync(exceptionContext));
                Assert.Null(result);
            }

            [Fact(DisplayName = "Exception Null")]
            public async Task OnExceptionFilterNull()
            {
                var actionContext = new ActionContext()
                {
                    HttpContext = new DefaultHttpContext(),
                    RouteData = new RouteData(),
                    ActionDescriptor = new ActionDescriptor()
                };

                var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
                {
                    Exception = null,
                };
                var exception = new ExeptionFilter();

                var result = await Record.ExceptionAsync(() => exception.OnExceptionAsync(exceptionContext));
                Assert.Null(result);
            }

        }
    }
}
