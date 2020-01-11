using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.Tests.SharingData
{
    public class UserSharingData : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> GetUserIdDataGenerator()
        {
            User user = new User();
            user.userId = 444;
            user.userName = "3333";
            user.userPassword = "123";
            user.userMail = "6666";

            yield return new object[] { 444, user };
        }

        public static IEnumerable<object[]> GetUserLList()
        {
            List<User> users = new List<User>()
            {
                new User(){ userId = 34, userName = "er", userPassword = "34ff", userMail = "eerg" },
                new User(){ userId = 35, userName = "erferfds", userPassword = "34ff", userMail = "eerg" },
                new User(){ userId = 36, userName = "ymumu", userPassword = "34ff", userMail = "eerg" },
                new User(){ userId = 37, userName = "sdfsdre", userPassword = "34ff", userMail = "eerg" },
                new User(){ userId = 38, userName = "ASASDAS", userPassword = "34ff", userMail = "eerg" }
            };
       
            yield return new object[] { users };
        }

        public static IEnumerable<object[]> addUser()
        {
            User newUser = new User();
            newUser.userId = 2;
            newUser.userName = "testUser";
            newUser.userPassword = "testPass123";
            newUser.userMail = "userMail@gmail.com";

            yield return new object[] { newUser, HttpStatusCode.Created };
        }

        public static IEnumerable<object[]> updateUser()
        {
            User updatedUser = new User();
            updatedUser.userId = 2;
            updatedUser.userName = "testUserUpdate";
            updatedUser.userPassword = "testPassUpdate";
            updatedUser.userMail = "userMailUpdate@gmail.com";

            yield return new object[] { updatedUser, HttpStatusCode.OK };
        }

        public static IEnumerable<object[]> deleteUser()
        {
            User user = new User();
            user.userId = 2;
            user.userName = "testUserUpdate";
            user.userPassword = "testPassUpdate";
            user.userMail = "userMailUpdate@gmail.com";

            yield return new object[] { user , HttpStatusCode.OK };
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
