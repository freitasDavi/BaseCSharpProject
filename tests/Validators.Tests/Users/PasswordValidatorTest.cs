using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests.Auth;
using CommonTestUtilities.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validators.Tests.Users
{
    public class PasswordValidatorTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData("aa")]
        [InlineData("aaa")]
        [InlineData("aaaa")]
        [InlineData("aaaaa")]
        [InlineData("aaaaaa")]
        [InlineData("aaaaaaa")]
        [InlineData("aaaaaaaa")]
        [InlineData("AAAAAAAA")]
        [InlineData("Aaaaaaaa")]
        [InlineData("Aaaaaaaa1")]
        public void ErrorInvalidPassword(string password)
        {
            // Arrange
            var validator = new PasswordValidator<RequestRegisterUserJson>();

            // Act
            var result = validator
                .IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), password);

            // Assert
            result.Should().BeFalse();
        }
    }
}
