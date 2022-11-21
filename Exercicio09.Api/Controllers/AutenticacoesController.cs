using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio09.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(InformacaoResponse), 400)]
    [ProducesResponseType(typeof(InformacaoResponse), 401)]
    [ProducesResponseType(typeof(InformacaoResponse), 403)]
    [ProducesResponseType(typeof(InformacaoResponse), 404)]
    [ProducesResponseType(typeof(InformacaoResponse), 500)]

    public class AutenticacoesController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AutenticacoesController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AutenticacaoResponse>> PostAsync([FromBody] AutenticacaoRequest request)
        {
            var response = await _usuarioService.AutenticarAsync(request.Email, request.Senha);
            return Ok(response);
        }

    }
}
