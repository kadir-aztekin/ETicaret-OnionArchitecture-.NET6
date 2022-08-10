﻿using ETicaret.Application.Repositories;
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
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
            

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query=Table.AsQueryable();
            if(!tracking)
                query=query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
       
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query=Table.AsQueryable();
            if (true)
            query= Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}
