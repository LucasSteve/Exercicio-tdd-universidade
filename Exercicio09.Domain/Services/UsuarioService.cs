using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Exceptions;
using Exercicio09.Domain.Interfaces.Repositories;
using Exercicio09.Domain.Interfaces.Services;
using Exercicio09.Domain.Settings;
using Exercicio09.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly AppSetting _appSettings;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, AppSetting appSettings,
                              IHttpContextAccessor httpContextAccesso) : base(usuarioRepository, httpContextAccesso)
        {
            _usuarioRepository = usuarioRepository;
            _appSettings = appSettings;
        }

        public async Task CriarUsuarioAsync(Usuario usuario)
        {
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha,BCrypt.Net.BCrypt.GenerateSalt());
            await AdicionarAsync(usuario);
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(
                usuario.Senha,
                BCrypt.Net.BCrypt.GenerateSalt()
            );
            await AlterarAsync(usuario);
        }

        public async Task AtualizarCpfAsync(int id, string cpf) 
        {
            var entity = await ObterPorIdAsync(id);
            entity.Cpf = cpf;
            entity.DataAlteracao = DateTime.Now;
            entity.UsuarioAlteracao = UserId;
            await _usuarioRepository.EditAsync(entity);
        }
      

        public async Task<List<Usuario>> ObterTodosUsuarioAsync()
        {
            if (UserPerfil == ConstanteUtil.PerfilAlunoNome)
                return await ObterTodosAsync(x => x.Ativo && x.Id == UserId);
            else
                return await ObterTodosAsync();
        }

        public async Task<Usuario> ObterPorIdUsuarioAsync(int id)
        {
            if (UserPerfil == ConstanteUtil.PerfilAlunoNome)
                return await ObterAsync(x => x.Id == id && x.Ativo && x.Id == UserId);
            else
                return await ObterPorIdAsync(id);
        }

        public async Task<AutenticacaoResponse> AutenticarAsync(string email, string senha)
        {
            var entity = await ObterAsync(x => x.Email.Equals(email) && x.Ativo);

            if (!BCrypt.Net.BCrypt.Verify(senha, entity.Senha))
                throw new InformacaoException(Enums.StatusException.FormatoIncorreto, "Usuário ou senha incorreta");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                    new Claim(ClaimTypes.Name, entity.Nome),
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim(ClaimTypes.Role, entity.Perfil.Nome)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.JwtSecurityKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new AutenticacaoResponse
            {
                Token = tokenString,
                DataExpiracao = tokenDescriptor.Expires
            };


        }
    }
}
