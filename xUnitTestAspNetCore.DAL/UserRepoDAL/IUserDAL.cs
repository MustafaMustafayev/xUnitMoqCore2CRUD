using System;
using System.Collections.Generic;
using System.Text;
using xUnitTestAspNetCore.Core.CRUDRepo;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.DAL.UserRepoDAL
{
    public interface IUserDAL : ICRUD<User>
    {
    }
}
