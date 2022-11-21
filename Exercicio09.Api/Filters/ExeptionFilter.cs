using Exercicio09.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Utils;
using Exercicio09.Domain.Exceptions;

namespace Exercicio09.Api.Filters
{
    public class ExeptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var response = new InformacaoResponse();

            if (context.Exception is InformacaoException)
            {
                var informacaoException = (InformacaoException)context.Exception;

                response.Codigo = informacaoException.Codigo;
                response.Mensagens = informacaoException.Mensagens;
                response.Detalhe = context.Exception?.InnerException?.Message;
            }
            else
            {
                response.Codigo = StatusException.Erro;
                response.Mensagens = new List<string> {"Erro inesperado"};
                response.Detalhe = context.Exception?.InnerException?.Message;
            }

            context.Result = new ObjectResult(response)
            {
                StatusCode = response.Codigo.GetStatusCode()
            };

            OnException(context);
            return Task.CompletedTask;
        }

    }
}
