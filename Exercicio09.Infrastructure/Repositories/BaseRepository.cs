using Azure;
using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Interfaces.Repositories;
using Exercicio09.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;


namespace Exercicio09.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity

    {
        private readonly Exercicio09Context _context;

        public BaseRepository(Exercicio09Context context)
        {
            _context = context;
        }

        public async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }      

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }              
            

        public async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
      

        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T item)
        {
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
        }

    


    }
}
