using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xUnitTestAspNetCore.BLL.UserRepoBLL;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _user;
        public UserController(IUserBLL user)
        {
            _user = user;
        }

        [HttpGet("getUsers")]
        public async Task<List<User>> getUsers()
        {
            List<User> users = await _user.getList();
            return users;
        }

        [HttpGet("getUserById/{id}")]
        public async Task<User> getUserById(string id)
        {
            User user = await _user.getById(id);
            return user;
        }

        [HttpPost("addUser")]
        public async Task<HttpStatusCode> addUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }
            HttpStatusCode response = await _user.add(user);
            return response;
        }

        [HttpPost("updateUser")]
        public async Task<HttpStatusCode> updateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }
            HttpStatusCode response = await _user.update(user);
            return response;
        }

        [HttpPost("deleteUser/{id}")]
        public async Task<HttpStatusCode> deleteUser(string id)
        {
            User user = await _user.getById(id);
            if (user != null)
            {
                HttpStatusCode response = await _user.delete(user);
                return response;
            }
            return HttpStatusCode.NotFound;
        }

        [HttpGet]
        public void ok()
        {

        }
    }
}