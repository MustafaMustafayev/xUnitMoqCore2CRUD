using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitTestAspNetCore.Entities.Models;
using xUnitTestAspNetCore.IntegrationTest.SharingData;

namespace xUnitTestAspNetCore.IntegrationTest.UserRepoIntegrationTest
{
    public class UserIntegrationTest
    {
        // configure base url on the json file
        [Fact]
        [Trait("UserIntegrationTest", "Get")]
        public async Task getUserList_ITest()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/user/getUsers");

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Theory]
        [Trait("UserIntegrationTest","Get")]
        [MemberData(nameof(UserSharingData.getUserById), MemberType = typeof(UserSharingData))]
        public async Task getUserById_ITest(string userId)
        {
            using (var client = new TestClientProvider().Client)
            {
                // pass base url to testClientProvider
                var response = await client.GetAsync(String.Format("/api/user/getUserById/{0}", userId));
                response.EnsureSuccessStatusCode();

                // Fluent Assertions
                response.StatusCode.Should().Be(HttpStatusCode.OK);

               //this is not fluent assertions
               //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Theory]
        [Trait("UserIntegrationTest", "Post")]
        [MemberData(nameof(UserSharingData.addUser), MemberType = typeof(UserSharingData))]
        public async Task addNewUser_ITest(User newUser)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/user/addUser", //base url
                                     new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json")); //body

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Theory]
        [Trait("UserIntegrationTest", "Post")]
        [MemberData(nameof(UserSharingData.updateUser), MemberType = typeof(UserSharingData))]
        public async Task updateUser_ITest(User updatedUser)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/user/updateUser", //base url
                                     new StringContent(JsonConvert.SerializeObject(updatedUser), Encoding.UTF8, "application/json")); //body

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Theory]
        [Trait("UserIntegrationTest", "Post")]
        [MemberData(nameof(UserSharingData.deleteUser), MemberType = typeof(UserSharingData))]
        public async Task deleteUser_ITest(string userId)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync(String.Format("/api/user/deleteUser/{0}",userId),null);

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

    }
}
