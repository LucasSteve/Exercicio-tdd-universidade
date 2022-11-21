using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Interfaces.Services
{
    public interface IBaseService<T>
    {
        Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> expression);
        Task<T> ObterAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task AdicionarAsync(T entity);
        Task DeletarAsync(int id);
        Task AlterarAsync(T entity);
        

    }
}
