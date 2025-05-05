using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Oerlikon.Core.Models.Users;

namespace Oerlikon.WebApi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task RegisterUser_ReturnSuccess()
        {
            var name = "adnan";
            var email = "adnansetiawan@gmail.com";
            var password = "pass";
            var userUid = Guid.NewGuid();
            // Arrange
            var registerMockupResponse = new Core.Models.Users.UserRegisterResponse
            {
                 UserUID = userUid
            };
            var mockUserRegisterService = new Mock<Core.Interfaces.IUserRegisterService>();
            mockUserRegisterService
                   .Setup(x => x.Register(It.Is<UserRegisterRequest>(req =>
                    req.Email == email &&
                    req.Name == name &&
                    req.Password == password)))
                .ReturnsAsync(registerMockupResponse);
              
            var mockAuthService = new Mock<Core.Interfaces.IAuthService>();

            var authController = new WebApi.Controllers.AuthController(mockUserRegisterService.Object, mockAuthService.Object);

            // Act
            var result = await authController.Register(new Dto.UserRegistrationApiRequest
            {
                 Email = email,
                 Name = name,
                 Password = password
            });

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(userUid, (okResult.Value as UserRegisterResponse).UserUID);
        }
    }
}