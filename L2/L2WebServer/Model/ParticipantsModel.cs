using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebServer.Model
{
    class ParticipantsModel
    {
        public static string viewContent(string siteFolder)
        {
            string filePath = siteFolder + "\\participants.html";
            if (File.Exists(filePath))
            {
                string fileText = File.ReadAllText(filePath);

                string jsonString = File.ReadAllText(siteFolder + "\\data\\json");
                var users = JsonConvert.DeserializeObject<List<Participant>>(jsonString);
                string userListTopage = "";
                foreach (var guest in users)
                {
                    userListTopage += "<li>" + guest.Name + "</li>";
                }
                return fileText.Replace("{participants}", userListTopage);
            }
            return "File not exist";
        }
    }
}
