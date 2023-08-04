using System;
using Moq;
using PruebaPersonalSoft.Models;
using PruebaPersonalSoft.Repositories.Users;
using PruebaPersonalSoft.Services;

namespace TestPruebaPersonalSoft.Service
{
	public class UserServiceTests
	{
        [Fact]
        public async Task GetUsers_ShouldReturnListOfUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = MongoDB.Bson.ObjectId.GenerateNewId(), email = "corenilio@gmail", password = "12345667" },
                new User { Id = MongoDB.Bson.ObjectId.GenerateNewId(), email = "tales@gmail", password = "987654321" }
            };

            var mockUserCollection = new Mock<IUserCollection>();
            mockUserCollection.Setup(db => db.GetAllUsers()).ReturnsAsync(users);

            var userService = new UserService { db = mockUserCollection.Object };

            // Act
            var result = await userService.GetUsers();

            // Assert
            Assert.Equal(users, result);
        }

        [Fact]
        public async Task AddUser_ShouldInsertUser()
        {
            // Arrange
            var newUser = new User { Id = MongoDB.Bson.ObjectId.GenerateNewId(), email = "corenilio@gmail", password = "12345667" };

            var mockUserCollection = new Mock<IUserCollection>();
            mockUserCollection.Setup(db => db.InsertUser(newUser)).Returns(Task.CompletedTask);

            var userService = new UserService { db = mockUserCollection.Object };

            // Act
            var result = await userService.AddUser(newUser);

            // Assert
            Assert.Equal(newUser, result);
        }
    }
}

