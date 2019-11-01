using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IntegrationsTests.TestHelpers;
using Newtonsoft.Json;
using NUnit.Framework;
using SlackNotifications.Data;

namespace IntegrationsTests.Controllers.DocsControllerTests
{
    public class PostDocsAsyncShould
    {
        [Test]
        public async Task ReturnOk()
        {
            var (status, content) = await PostDocAsync(new Document
            {
                Name = "Test User",
                FileUrl = "https://linktofile.file/file/133.pdf",
                Requirements = new List<string> {"'Test User' as business owner"}
            });
            
            Assert.AreEqual(HttpStatusCode.OK, status);
        }
        
        private async Task<(HttpStatusCode status, string content)> PostDocAsync(Document document)
        {

            var jsonContent = JsonConvert.SerializeObject(document);
            
            using (var client = TestServerHelper.CreateClient())
            using(var response = await client.PostAsync("api/docs", new StringContent(jsonContent, Encoding.UTF8, "application/json")))
            {
                return (response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        } 
    }
    
    
}