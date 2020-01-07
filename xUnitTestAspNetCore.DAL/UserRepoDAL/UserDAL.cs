using System;
using System.Collections.Generic;
using System.Text;
using xUnitTestAspNetCore.Core.CRUDRepo;
using xUnitTestAspNetCore.DAL.Contexts;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.DAL.UserRepoDAL
{
    public class UserDAL : CRUD<User, UserDataContext>, IUserDAL
    {
    }
}
