using ArithmeticExecuteServices.Models;
using ArithmeticExecuteServices.Services.Implementations;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ArithmeticExecute.Tests.UnitTests
{
    public class LoginTest
    {
        [Test]
        public void LoginTest1()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["http://localhost:50352/"]).Returns("http://localhost:50352/");
            configuration.Setup(c => c["http://localhost:50352/"]).Returns("http://localhost:50352/");


            var authorizeService = new AuthorizeService(configuration.Object);
            var loginModel = new AuthorizeModel { UserName = "Admin", Password = "123" };

            // Act
            string token = authorizeService.AuthorizeFunc(loginModel);

            // Assert
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);
        }
    }
}