using System.Reflection.Metadata.Ecma335;

namespace UnitTests
{
    using System;
    using Domain;
    using Domain.Entities;
    using Domain.Services;
    using Moq;
    using Xunit;

    public class PensionServiceV2UnitTests
    {

        private Person personUnderTest;
        private Mock<IPersonRepository> mockPersonRepo;
        private Mock<IMailSender> mailSenderMock;

        [Fact]
        public void PersonWithAge38_ShouldNotHavePensionAndShouldNotBeNotified()
        {
            // arrange
            Setup(new DateTime(1981, 1, 1));
            PensionServiceV2 sut = new PensionServiceV2(mockPersonRepo.Object, mailSenderMock.Object);
            // act
            var actual = sut.Calculate(personUnderTest.Id);

            // assert
            var expected = false;
            Assert.Equal(expected, actual.IsPensionable);
            mailSenderMock.Verify(ms => ms.Send(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void PersonWithAge42_ShouldNotHavePensionAndShouldBeNotified()
        {

            // arrange
            Setup(new DateTime(1977, 1, 1));
            PensionServiceV2 sut = new PensionServiceV2(mockPersonRepo.Object, mailSenderMock.Object);
            // act
            var actual = sut.Calculate(personUnderTest.Id);
            // assert
            var expected = false;
            Assert.Equal(expected, actual.IsPensionable);

            mailSenderMock.Verify(ms => ms.Send(It.Is<string>(p =>  p == "welcome to pension")), Times.Once);
        }

        [Fact]
        public void PersonWithAge52_ShouldHavePensionAndShouldBeNotified()
        {
            // arrange
            Setup(new DateTime(1967, 1, 1));
            PensionServiceV2 sut = new PensionServiceV2(mockPersonRepo.Object, mailSenderMock.Object);
            // act
            var actual = sut.Calculate(personUnderTest.Id);
            // assert
            var expected = true;
            Assert.Equal(expected, actual.IsPensionable);

            mailSenderMock.Verify(ms => ms.Send(It.Is<string>(p => p == "welcome to pension")), Times.Once);
        }

        private void Setup(DateTime age)
        {
            personUnderTest = new Person
            {
                FullName = "Andrei",
                Id = Guid.NewGuid(),
                DateOfBirth = age
            };
            mockPersonRepo = new Mock<IPersonRepository>();

            mockPersonRepo
                .Setup(r => r.Get(personUnderTest.Id))
                .Returns(personUnderTest);


            mailSenderMock = new Mock<IMailSender>();
        }
    }
}
