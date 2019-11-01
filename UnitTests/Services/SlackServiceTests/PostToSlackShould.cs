using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SlackNotifications.Services;
using SlackNotifications.Services.Slack;

namespace UnitTests.Services.SlackServiceTests
{
    public class PostToSlackShould
    {
        private Mock<ISlackClient> _mockSlackClient;
        private SlackService _slackService;

        [SetUp]
        public void SetUp()
        {
            _mockSlackClient = new Mock<ISlackClient>();
            _slackService = new SlackService(_mockSlackClient.Object);
        }

        [Test]
        public async Task CallSlackClientPostMessage()
        {
            _mockSlackClient.Setup(x => x.PostMessage(It.IsAny<string>(), null)).Returns("ok");

            await _slackService.PostToSlack("Test Message");
            
            _mockSlackClient.Verify(x => x.PostMessage(It.IsAny<string>(), null), Times.Once);
        }
    }
}