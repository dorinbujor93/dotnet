using System;
using _6.Twitter.Interfaces;
using _6.Twitter.Models;
using Xunit;
using Moq;


namespace Test2
{
    public class UnitTest1
    {
        private Mock<IWriter> mockedWriter;
        private Mock<ITweetRepository> mockedITweetRepository;
        private MicrowaveOven sut;

        public UnitTest1()
        {
            mockedWriter = new Mock<IWriter>();
            mockedITweetRepository = new Mock<ITweetRepository>();
            sut = new MicrowaveOven(mockedWriter.Object, mockedITweetRepository.Object);
        }

        [Fact]
        public void SendTweetShouldSendTheMessageToServer()
        {
            // arrange
            var message = string.Empty;
            var sentMessage = "Tweet that has been sent";
            mockedITweetRepository.Setup(o => o.SaveTweet(It.IsAny<string>()))
                .Callback((string mess) => message = mess);
            //act
            sut.SendTweetToServer(sentMessage);
            //assert
            mockedITweetRepository.Verify(o => o.SaveTweet(sentMessage), Times.Exactly(1));
            Assert.Equal(sentMessage, message);
        }

        [Fact]
        public void WriteTweetShouldCallItsWriterWithTheTweetsMessage()
        {
            // arrange
            var message = string.Empty;
            var sentMessage = "Tweet that has been sent";

            mockedWriter.Setup(o => o.WriteLine(It.IsAny<string>())).Callback((string mess) => message = mess);
            //act
            sut.WriteTweet(sentMessage);
            //assert
            mockedWriter.Verify(o => o.WriteLine(It.IsAny<string>()), Times.Exactly(1));
            Assert.Equal(sentMessage, message);
        }

        [Fact]
        public void WriteTweetShouldCallItsWriterWithTheTweetsMsg()
        {
            // arrange
            var sentMessage = "Tweet that has been sent";
            mockedWriter.Setup(w => w.WriteLine(It.IsAny<string>()));
            // act
            sut.WriteTweet(sentMessage);
            // assert
            mockedWriter.Verify(w => w.WriteLine(It.Is<string>(s => s == sentMessage)),
                $"Tweet not sent to {typeof(MicrowaveOven)}'s mockedWriter");
        }
    }
}