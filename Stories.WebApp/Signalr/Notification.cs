using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Signalr
{
    public class Notification
    {
        public string FromUser { get; set; }
        public string Body { get; set; }
        public int StoryId { get; set; }
    }
}