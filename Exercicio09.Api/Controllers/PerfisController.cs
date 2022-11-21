using AutoMapper;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Services;
using Exercicio09.Domain.Services;
using Exercicio09.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Exercicio09.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ConstanteUtil.PerfilProfessorNome)]
    public class PerfisController : BaseController<Perfil, PerfilRequest, PerfilResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPerfilService _perfilService;
        public PerfisController(IMapper mapper, IPerfilService service) : base(mapper, service)
        {
            _mapper = mapper;
            _perfilService = service;
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PatchAsync([FromRoute] int id, [FromBody] PerfilRequest request)
        {
            await _perfilService.AtualizarNomeAsync(id, request.Nome);
            return Ok();
        }
    }
}
