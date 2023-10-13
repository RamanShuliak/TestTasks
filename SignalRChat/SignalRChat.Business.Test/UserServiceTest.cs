using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalRChat.Business.Hubs;
using SignalRChat.Business.ServicesImplementation;
using SignalRChat.Core.Abstractions;
using SignalRChat.Data.Abstractions;
using SignalRChat.DataBase.Entities;

namespace SignalRChat.Business.Test
{
    public class UserServiceTest
    {
        public readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        public readonly Mock<IHubContext<ChatHub>> _hubContextMock = new Mock<IHubContext<ChatHub>>();

        private UserService GetMokedUserService()
        {
            var userService = new UserService(_hubContextMock.Object, _unitOfWorkMock.Object);

            return userService;
        }

        [Fact]
        public async Task CreateNewUser_WithCorrectEnteredData_ReturnUserId()
        {
            var userId = Guid.NewGuid();

            var userName = "John";

            var service = GetMokedUserService();

            _unitOfWorkMock.Setup(uow => uow.Users.AddAsync(It.IsAny<User>()))
                .Callback<User>(user =>
                {
                    user.Id = userId;
                });

            var result = await service.CreateNewUser(userName);

            Assert.Equal(userId, result);
            _unitOfWorkMock.Verify(uow => uow.Users.AddAsync(It.IsAny<User>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateNewUser_WithNullableUserName_ThrowsArgumentException()
        {
            string userName = null;

            var service = GetMokedUserService();

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateNewUser(userName));
        }
    }
}