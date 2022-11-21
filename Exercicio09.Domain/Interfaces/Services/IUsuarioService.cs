using Exercicio09.Domain.Contracts.Responses;
using Exercicio09.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task<AutenticacaoResponse> AutenticarAsync(string email, string senha);        
        Task<List<Usuario>> ObterTodosUsuarioAsync();
        Task<Usuario> ObterPorIdUsuarioAsync(int id);
        Task AtualizarCpfAsync(int id, string cpf);
        Task CriarUsuarioAsync(Usuario usuario);

    }
}
