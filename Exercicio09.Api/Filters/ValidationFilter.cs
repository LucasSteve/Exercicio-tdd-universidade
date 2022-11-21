using Exercicio09.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Exercicio09.Domain.Contracts.Responses;

namespace Exercicio09.Api.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next
        )
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .SelectMany(p => p.Value.Errors)
                    .Select(p => p.ErrorMessage)
                    .ToList();
                var response = new InformacaoResponse
                {
                    Codigo = StatusException.FormatoIncorreto,
                    Mensagens = errors
                };
                context.Result = new ObjectResult(response) { StatusCode = 400 };
            }

            OnResultExecuting(context);
            if (!context.Cancel)
            {
                OnResultExecuted(await next());
            }

        }
    }
}
