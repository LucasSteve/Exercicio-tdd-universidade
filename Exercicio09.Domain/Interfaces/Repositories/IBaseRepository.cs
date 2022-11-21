using Exercicio09.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> FindAsync(int id);
       
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);       
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);      
       
        Task AddAsync(T item);
        Task RemoveAsync(T item);
        Task EditAsync(T item);
        
    }
}
