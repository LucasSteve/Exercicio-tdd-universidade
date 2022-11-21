using AutoMapper;
using Exercicio09.Domain.Contracts.Requests;
using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio09.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoService _enderecoService;

        public EnderecosController(IMapper mapper, IEnderecoService enderecoService) 
        {
            _mapper = mapper;
            _enderecoService= enderecoService;
        }     

        [HttpGet("cep/{cep}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetPorCep([FromRoute] string cep)
        {
            var entity = await _enderecoService.GetPorCep(cep);
            var endereco = _mapper.Map<EnderecoApiResponse>(entity);
            return Ok(endereco);
        }

    }
}
