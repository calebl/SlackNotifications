using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using SlackNotifications;

namespace IntegrationsTests.TestHelpers
{
    public static class TestServerHelper
    {
        private static TestServer _testServer;

        private static IWebHostBuilder CreateWebHostBuilder() =>
            WebHost
                .CreateDefaultBuilder()
                .UseSolutionRelativeContentRoot("SlackNotifications")
                .UseEnvironment("Development")
                .UseStartup<Startup>();

        public static void StartTestServer()
        {
            _testServer = new TestServer(CreateWebHostBuilder());
        }

        public static void StopTestServer()
        {
            _testServer?.Dispose();
            _testServer = null;
        }

        public static HttpClient CreateClient()
        {
            return _testServer.CreateClient();
        }

        public static HttpClient CreateClientWithPartnerTokenAuthentication(string tokenValue = "2CD9713F-8CF4-49EC-AA8B-12B5FFF49FEF")
        {
            var client = CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", tokenValue);
            return client;
        }
    }
}
