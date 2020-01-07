using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xUnitTestAspNetCore.DAL.UserRepoDAL;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.BLL.UserRepoBLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _user;

        public UserBLL(IUserDAL user)
        {
            _user = user;
        }

        public async Task<HttpStatusCode> add(User user)
        {
            return await _user.add(user);
        }

        public async Task<HttpStatusCode> delete(User user)
        {
            return await _user.delete(user);
        }

        public async Task<User> getById(string id)
        {
            User user = await _user.Get(p => p.userId == Convert.ToInt32(id));
            return user;
        }

        public async Task<List<User>> getList()
        {
            List<User> user = await _user.getList();
            return user;
        }

        public async Task<HttpStatusCode> update(User user)
        {
            return await _user.update(user);
        }
    }
}
