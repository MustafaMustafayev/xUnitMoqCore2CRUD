using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xUnitTestAspNetCore.Core.EntitiesCore;

namespace xUnitTestAspNetCore.Core.CRUDRepo
{
    public class CRUD<TEntity, TContext> : ICRUD<TEntity> where TEntity : class, IEntity, new()
                                                                                   where TContext : DbContext, new()
    {
        public async Task<HttpStatusCode> add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntry = context.Entry(entity);
                addedEntry.State = EntityState.Added;
                await context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
        }
         
        public async Task<HttpStatusCode> delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntry = context.Remove(entity);
                addedEntry.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> getList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<HttpStatusCode> update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntry = context.Entry(entity);
                addedEntry.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
        }
    }
}
