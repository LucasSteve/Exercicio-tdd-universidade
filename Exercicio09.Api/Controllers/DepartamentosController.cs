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
    public class DepartamentosController : BaseController<Departamento, DepartamentoRequest, DepartamentoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoService _departamentoService;
        public DepartamentosController(IMapper mapper, IDepartamentoService departamentoService) : base(mapper, departamentoService)
        {
            _mapper = mapper;
            _departamentoService= departamentoService;
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PatchAsync([FromRoute] int id, [FromBody] DepartamentoNomeRequest request)
        {
            await _departamentoService.AtualizarNomeAsync(id, request.Nome);
            return Ok();
        }
    }
}
