namespace SlackNotifications.Infrastructure
{
    public class Config
    {
        public SlackConfig Slack { get; set; } = new SlackConfig();
    }

    public class SlackConfig
    {
        public bool Enabled { get; set; }
        public string Url { get; set; }
    }
}