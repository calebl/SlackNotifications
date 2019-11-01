using NUnit.Framework;
using SlackNotifications.Infrastructure;
using SlackNotifications.Services.Slack;

namespace IntegrationsTests.Services.SlackClientTests
{
    public class PostMessageShould
    {
        private readonly Config _config = new Config
        {
            Slack = new SlackConfig
            {
                Url = System.Environment.GetEnvironmentVariable("SLACK_URL")
            }
        };

        [Test]
        public void SendToSlack()
        {
            var client = new SlackClient(_config);
	
            var result = client.PostMessage(
                "THIS IS A TEST MESSAGE!");
            
            Assert.AreEqual("ok", result);
        }
    }
}