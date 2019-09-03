using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebServer.Controllers
{
    class VoteController : TemplateController
    {
        public override void ConstractPage(string siteFolder, HttpListenerContext context)
        {

            string guestName = "";
            string visitParty = "False";
            if (context.Request.HttpMethod == "GET")
            {
                var requestParams = HttpUtility.ParseQueryString(context.Request.QueryString.ToString());
            }

            if (context.Request.HttpMethod == "POST")
            {

            }

            string filePath = siteFolder + "\\data\\json";
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<Participant>>(jsonString);
                users.Add(new Participant() { guest = guestName });
                File.WriteAllText(filePath, JsonConvert.SerializeObject(users));
                //use our class with participants
                var participantsView = new ParticipantsController();
                participantsView.ConstractPage(siteFolder, context);
            }
        }
    }
}
