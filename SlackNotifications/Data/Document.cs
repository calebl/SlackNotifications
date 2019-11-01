using System;
using System.Collections.Generic;

namespace SlackNotifications.Data
{
    [Serializable]
    public class Document
    {
        public string Name { get; set; }
        public string FileUrl { get; set; }
        public List<string> Requirements { get; set; }
    }
}