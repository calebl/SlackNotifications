using System.Threading.Tasks;
using SlackNotifications.Data;

namespace SlackNotifications.Services
{
    public class DocsService : IDocsService
    {
        private readonly ISlackService _slackService;

        public DocsService(ISlackService slackService)
        {
            _slackService = slackService;
        }
        
        public async Task SubmitDocumentAsync(Document document)
        {
            //TODO save the document
            
            await PostSlackNotification(document);
        }
        
        private async Task PostSlackNotification(Document document)
        {
            var message = $"New Document submitted for `{document.Name}`";

            await _slackService.PostToSlack(message);

        }
    }

    public interface IDocsService
    {
        Task SubmitDocumentAsync(Document document);
    }
}