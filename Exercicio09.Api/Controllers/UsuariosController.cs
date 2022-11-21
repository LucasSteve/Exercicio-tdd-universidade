using AutoMapper;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Services;
using Exercicio09.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Exercicio09.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ConstanteUtil.PerfilLogadoNome)]
    public class UsuariosController : BaseController<Usuario, UsuarioRequest, UsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IMapper mapper, IUsuarioService usuarioService) : base(mapper, usuarioService)
        {
            _mapper = mapper;
            _usuarioService= usuarioService;
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PatchAsync([FromRoute] int id, [FromBody] UsuarioCpfRequest request)
        {
            await _usuarioService.AtualizarCpfAsync(id, request.Cpf);
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(201)]
        public override async Task<ActionResult> PostAsync([FromBody] UsuarioRequest request)
        {
            var entity = _mapper.Map<Usuario>(request);
            await _usuarioService.CriarUsuarioAsync(entity);
            return Created(nameof(PostAsync), new { id = entity.Id });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public override async Task<ActionResult<UsuarioResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _usuarioService.ObterPorIdUsuarioAsync(id);
            return Ok(_mapper.Map<UsuarioResponse>(entity));
        }



    }
}
