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
    [Authorize(Roles = ConstanteUtil.PerfilProfessorNome)]
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : BaseController<Curso, CursoRequest, CursoResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICursoService _cursoService;
        public CursosController(IMapper mapper, ICursoService cursoService) : base(mapper, cursoService)
        {
            _mapper = mapper;
            _cursoService = cursoService;
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PatchAsync([FromRoute] int id, [FromBody] CursoTurnoRequest request)
        {
            await _cursoService.AtualizarTurnoAsync(id, request.Turno);
            return Ok();
        }
    }
}
