using ETicaret.Application.Repositories;
using ETicaret.Domain.Entites.Common;
using ETicaret.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretDbContext _eTicaretDbContext;

        public ReadRepository(ETicaretDbContext eTicaretDbContext)
        {
            _eTicaretDbContext = eTicaretDbContext;
        }

        public DbSet<T> Table => _eTicaretDbContext.Set<T>();
        public IQueryable<T> GetAll()
        
            =>Table;

        public async Task<T> GetByIdAsync(string id)
        => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);
    }
}
