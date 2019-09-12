using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebServer.Model
{
    class VoteModel
    {
        public static void addParticipant(string participantName,string siteFolder)
        {
            string filePath = siteFolder + "\\data\\json";
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<Participant>>(jsonString);
                users.Add(new Participant(participantName,true,""));
                File.WriteAllText(filePath, JsonConvert.SerializeObject(users));
            }
        }
    }
}
