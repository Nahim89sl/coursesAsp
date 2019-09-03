using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebServer.Controllers
{
    class ParticipantsController : TemplateController
    {
        public override void ConstractPage(string siteFolder, HttpListenerContext context)
        {
            string filePath = siteFolder + "\\participants.html";
            if (File.Exists(filePath))
            {
                string fileText = File.ReadAllText(filePath);

                string jsonString = File.ReadAllText(siteFolder +"\\data\\json");
                var users = JsonConvert.DeserializeObject<List<Participant>>(jsonString);
                string userListTopage = "";
                foreach (var guest in users)
                {
                    userListTopage += "<li>" + guest.guest + "</li>";
                }

                Handle(context, fileText.Replace("{participants}", userListTopage));
            }
        }
    }
}
