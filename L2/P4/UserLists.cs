using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WebServer
{
    class UserLists
    {
        [JsonProperty("Participant")]
        public Participant[] participants { set; get; }
    }
    class Participant
    {
        [JsonProperty("username")]
        public string guest { set; get; }
    }

}
