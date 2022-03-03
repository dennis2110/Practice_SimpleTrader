using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [Test]
        public async void Login_WithCorrectPasswordForExistingUsername_ReturnsAccountForCorrectUsername()
        {
            //Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            Mock<IAccountService> mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername} });
            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher>();
            AuthenticationService authenticationService = new AuthenticationService(mockAccountService.Object, mockPasswordHasher.Object);

            //Act
            Account account = await authenticationService.Login(expectedUsername, password);

            //Assert
            string actualUsername = account.AccountHolder.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }
    }
}
