using Microsoft.Extensions.DependencyInjection;
using Moq;
using PhoneBookApp.Application.Interfaces;
using PhoneBookApp.Application.Services;
using PhoneBookApp.Domain.Entities;
using Xunit;

namespace PhoneBookApp.Tests
{
    public class PhoneBookServiceTests
    {
        [Fact]
        public void GetPhoneNumberByPersonName_ShouldReturnPhoneBookEntry_WhenPersonNameExists()
        {
            // Arrange
            var personNameToFind = "John Doe";
            var expectedPhoneBookEntry = new PhoneBookEntry(personNameToFind, "123456789"); 
            var phoneBookEntries = new List<PhoneBookEntry>
            {
                expectedPhoneBookEntry,
                new PhoneBookEntry("Jane Smith", "987654321"),
                new PhoneBookEntry("Alice Johnson", "555555555"),
            };

            var phoneBookRepositoryMock = new Mock<IPhoneBookRepository>();
            phoneBookRepositoryMock.Setup(repo => repo.GetPhoneNumberByPersonName(personNameToFind)).Returns(expectedPhoneBookEntry);

            var serviceProvider = new ServiceCollection()
                .AddSingleton(phoneBookRepositoryMock.Object)
                .AddSingleton<IPhoneBookService, PhoneBookService>()
                .BuildServiceProvider();

            var phoneBookService = serviceProvider.GetService<IPhoneBookService>();

            // Act
            var result = phoneBookService.GetPhoneNumberByPersonName(personNameToFind);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPhoneBookEntry.PersonName, result.PersonName);
            Assert.Equal(expectedPhoneBookEntry.PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        public void GetPhoneNumberByPersonName_ShouldReturnNull_WhenPersonNameDoesNotExist()
        {
            // Arrange
            var personNameToFind = "John Doe";
            var phoneBookEntries = new List<PhoneBookEntry>
            {
                new PhoneBookEntry("Jane Smith", "987654321"),
                new PhoneBookEntry("Alice Johnson", "555555555"),
            };

            var phoneBookRepositoryMock = new Mock<IPhoneBookRepository>();
            phoneBookRepositoryMock.Setup(repo => repo.GetPhoneNumberByPersonName(personNameToFind)).Returns((PhoneBookEntry)null);

            var serviceProvider = new ServiceCollection()
                .AddSingleton(phoneBookRepositoryMock.Object)
                .AddSingleton<IPhoneBookService, PhoneBookService>()
                .BuildServiceProvider();

            var phoneBookService = serviceProvider.GetService<IPhoneBookService>();

            // Act
            var result = phoneBookService.GetPhoneNumberByPersonName(personNameToFind);

            // Assert
            Assert.Null(result);
        }
    }
}
