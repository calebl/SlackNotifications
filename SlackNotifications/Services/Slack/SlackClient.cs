using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using SlackNotifications.Infrastructure;

namespace SlackNotifications.Services.Slack
{
    public class SlackClient : ISlackClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();
    
        public SlackClient(Config config)
        {
            _uri = new Uri(config.Slack.Url);
        }

        //Post a message using simple strings
        public string PostMessage(string text, string channel = null)
        {
            var payload = new Payload
            {
                Channel = channel,
                Text = text
            };

            return PostMessage(payload);
        }

        //Post a message using a Payload object
        private string PostMessage(Payload payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);

            using (var client = new WebClient())
            {
                var data = new NameValueCollection {["payload"] = payloadJson};

                var response = client.UploadValues(_uri, "POST", data);

                //The response text is usually "ok"
                return _encoding.GetString(response);
            }
        }
    }

//This class serializes into the Json payload required by Slack Incoming WebHooks
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public interface ISlackClient
    {
        string PostMessage(string text, string channel = null);
    }
}