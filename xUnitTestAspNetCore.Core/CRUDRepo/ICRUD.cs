using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xUnitTestAspNetCore.Core.EntitiesCore;

namespace xUnitTestAspNetCore.Core.CRUDRepo
{
    public interface ICRUD<T> where T : class, IEntity, new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter = null);

        Task<List<T>> getList(Expression<Func<T, bool>> filter = null);

        Task<HttpStatusCode> add(T entity);
        Task<HttpStatusCode> update(T entity);
        Task<HttpStatusCode> delete(T entity);
    }
}
