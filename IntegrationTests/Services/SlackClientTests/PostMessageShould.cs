using NUnit.Framework;
using SlackNotifications.Services.Slack;

namespace IntegrationsTests.Services.SlackClientTests
{
    public class PostMessageShould
    {

        [Test]
        public void SendToSlack()
        {
            var client = new SlackClient();
	
            var result = client.PostMessage(
                "THIS IS A TEST MESSAGE!");
            
            Assert.AreEqual("ok", result);
        }
    }
}