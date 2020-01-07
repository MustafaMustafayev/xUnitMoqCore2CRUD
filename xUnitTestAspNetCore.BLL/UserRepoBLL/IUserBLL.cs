using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.BLL.UserRepoBLL
{
    public interface IUserBLL
    {
        Task<List<User>> getList();
        Task<User> getById(string id);
        Task<HttpStatusCode> add(User user);
        Task<HttpStatusCode> update(User user);
        Task<HttpStatusCode> delete(User user);
    }
}
