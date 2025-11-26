
using Moq;
using WpfAppDemo.Models.Entities;
using WpfAppDemo.Models.Repositories.Interfaces;
using WpfAppDemo.ViewModels.Services;

namespace WpfAppDemoTests.Services
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private AuthenticationService _authService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();

            // Initialize the service
            _authService = new AuthenticationService(
                _mockUserRepository.Object
            );
        }

        [Test]
        public void UserExists_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            User user = new()
            {
                Username = "test",
                Password = "123456"
            };

            SetupUserMock(user, "test");

            // Act
            bool result = _authService.UserExists("test", "123456");

            // Assert
            Assert.IsTrue(result, "UserExists should return true for correct username and password.");
        }

        [Test]
        public void UserExists_InvalidCredentials_ReturnsFalse()
        {
            // Arrange  
            User user = new()
            {
                Username = "test",
                Password = "invalid"
            };

            SetupUserMock(user, "test");

            // Act
            bool result = _authService.UserExists("test", "wrong");

            // Assert
            Assert.IsFalse(result, "UserExists should return false when the user does not exist.");
        }

        [Test]
        public void UserExists_EmptyCredentials_ReturnsFalse()
        {
            // Arrange  
            User user = new()
            {
                Username = "test",
                Password = "invalid"
            };

            SetupUserMock(user, "test");

            // Act
            bool result = _authService.UserExists("", "");

            // Assert
            Assert.IsFalse(result, "UserExists should return false when the user does not exist.");
        }

        [Test]
        public void CreateUser_EmptyCredentials_ReturnsFalse()
        {
            // Act
            bool result = _authService.CreateUser("", "", "");

            // Assert
            Assert.IsFalse(result, "CreateUser should return false when credentials are empty.");
        }

        private void SetupUserMock(User? user, string username)
        {
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(username)).Returns(user);
        }
    }
}
