using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace Exercicio09.Api.Handlers
{
    public class AuthorizationHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly IAuthorizationMiddlewareResultHandler _handler;

        public AuthorizationHandler()
        {
            _handler = new AuthorizationMiddlewareResultHandler();
        }

        public async Task HandleAsync(
            RequestDelegate requestDelegate,
            HttpContext httpContext,
            AuthorizationPolicy authorizationPolicy,
            PolicyAuthorizationResult policyAuthorizationResult)
        {
            var informacaoResponse = new InformacaoResponse();

            if (!policyAuthorizationResult.Succeeded)
            {
                if (policyAuthorizationResult.Forbidden)
                {
                    httpContext.Response.StatusCode = 403;
                    informacaoResponse = new InformacaoResponse
                    {
                        Codigo = StatusException.AcessoProibido,
                        Mensagens = new List<string> { "Acesso não permitido" }
                    };
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    informacaoResponse = new InformacaoResponse
                    {
                        Codigo = StatusException.NaoAutorizado,
                        Mensagens = new List<string> { "Acesso negado" }
                    };
                }

                await httpContext.Response.WriteAsJsonAsync(informacaoResponse);
            }
            else
                await _handler.HandleAsync(requestDelegate, httpContext, authorizationPolicy, policyAuthorizationResult);

        }
    }
}
