using System.Threading.Tasks;
using SlackNotifications.Infrastructure;
using SlackNotifications.Services.Slack;

namespace SlackNotifications.Services
{
    public class SlackService : ISlackService
    {
        private readonly ISlackClient _slackClient;

        public SlackService(ISlackClient slackClient)
        {
            _slackClient = slackClient;
        }

        public async Task<string> PostToSlack(string message)
        {
        
            var response = _slackClient.PostMessage(message);

            return response;
        }
    }

    public interface ISlackService
    {
        Task<string> PostToSlack(string message);
    }
}