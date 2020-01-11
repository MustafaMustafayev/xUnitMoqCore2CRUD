using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitTestAspNetCore.BLL.UserRepoBLL;
using xUnitTestAspNetCore.Controllers;
using xUnitTestAspNetCore.Entities.Models;
using xUnitTestAspNetCore.Tests.SharingData;

namespace xUnitTestAspNetCore.Tests.UserRepoTest
{
    public class UserFixture
    {
        public Mock<IUserBLL> _mockBll;
        public UserFixture()
        {
            _mockBll = new Mock<IUserBLL>();
        }
        public UserController userFixture => new UserController(_mockBll.Object);
    }

    public class UserTest : IClassFixture<UserFixture>, IDisposable
    {
        private readonly UserFixture _userFixture;

        public UserTest(UserFixture userFixture)
        {
            _userFixture = userFixture;
        }

        [Theory]
        [Trait("User", "GET")]
        [MemberData(nameof(UserSharingData.GetUserLList), MemberType = typeof(UserSharingData))]
        public async Task getUserList_Test(List<User> expected)
        {
            _userFixture._mockBll.Setup(x => x.getList())
                        .ReturnsAsync(expected);

            var _user = _userFixture.userFixture;
            var actually = await _user.getUsers();

            Assert.IsType<List<User>>(actually);
            Assert.Equal(expected, actually);
        }


        [Theory]
        [Trait("User", "GET")]
        [MemberData(nameof(UserSharingData.GetUserIdDataGenerator), MemberType = typeof(UserSharingData))]
        public async Task getUserById_Test(int value, User expected)
        {
            _userFixture._mockBll.Setup(x => x.getById(value.ToString()))
                         .ReturnsAsync(expected);

            var _user = _userFixture.userFixture;    
            var actually = await _user.getUserById(value.ToString());

            Assert.NotNull(actually);
            Assert.Same(expected, actually);
            Assert.IsType<User>(actually);
        }

        [Theory]
        [Trait("User", "POST")]
        [MemberData(nameof(UserSharingData.addUser), MemberType = typeof(UserSharingData))]
        public async Task addUser_Test(User newUser, HttpStatusCode expected)
        {
            _userFixture._mockBll.Setup(x => x.add(newUser))
                        .ReturnsAsync(expected);

            var _user = _userFixture.userFixture;
            var actually = await _user.addUser(newUser);

            Assert.Equal(expected, actually);
            Assert.IsType<HttpStatusCode>(actually);
        }

        [Theory]
        [Trait("User", "POST")]
        [MemberData(nameof(UserSharingData.updateUser), MemberType = typeof(UserSharingData))]
        public async Task updateUser_Test(User updatedUser, HttpStatusCode expected)
        {
            _userFixture._mockBll.Setup(x => x.update(updatedUser))
                        .ReturnsAsync(expected);

            var _user = _userFixture.userFixture;
            var actually = await _user.updateUser(updatedUser);

            Assert.Equal(expected, actually);
            Assert.IsType<HttpStatusCode>(actually);
        }

        [Theory]
        [Trait("User", "POST")]
        [MemberData(nameof(UserSharingData.deleteUser), MemberType = typeof(UserSharingData))]
        public async Task deleteUser_Test(User user, HttpStatusCode expected)
        {
            _userFixture._mockBll.Setup(x => x.getById(user.userId.ToString()))
                        .ReturnsAsync(user);

            _userFixture._mockBll.Setup(x => x.delete(user))
                        .ReturnsAsync(expected);

            var _user = _userFixture.userFixture;
            var actually = await _user.deleteUser(user.userId.ToString());

            Assert.Equal(expected, actually);
            Assert.IsType<HttpStatusCode>(actually);
        }

        public void Dispose()
        {
            // Clean codes
        }

    }
}
