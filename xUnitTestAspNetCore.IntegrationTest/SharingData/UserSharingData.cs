using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.IntegrationTest.SharingData
{
    class UserSharingData : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> getUserById()
        {
            yield return new object[] { "1" };
        }

        public static IEnumerable<object[]> addUser()
        {
            User newUser = new User();
            newUser.userId = 22324;
            newUser.userName = "erfergerg";
            newUser.userPassword = "ergerger";
            newUser.userMail = "ergerger22323@gmail.com";

            yield return new object[] { newUser };
        }

        public static IEnumerable<object[]> updateUser()
        {
            User newUser = new User();
            newUser.userId = 22324;
            newUser.userName = "okokok";
            newUser.userPassword = "okokok";
            newUser.userMail = "okokok@gmail.com";

            yield return new object[] { newUser };
        }

        public static IEnumerable<object[]> deleteUser()
        {
            yield return new object[] { "27" };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
