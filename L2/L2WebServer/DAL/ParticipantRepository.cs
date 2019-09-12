using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebServer.Model;

namespace WebServer.DAL
{
    class ParticipantRepository  : IParticipantRepository
    {
        private List<Participant> Participants { set; get; }
        private string JsonFilePath { get; }
        public ParticipantRepository(string siteFolder)
        {
            JsonFilePath = siteFolder+"data\\json";
            var json = File.ReadAllText(JsonFilePath);
            Participants = JsonConvert.DeserializeObject<List<Participant>>(json);
            if(Participants==null)
            {
                Participants = new List<Participant>();
            }
        }

        public List<Participant> List()
        {
            return Participants;
        }

        public Participant Get(string name)
        {
            return Participants.FirstOrDefault(x => x.Name == name);
        }

        public void Commit()
        {
            var jsonText = JsonConvert.SerializeObject(Participants);
            File.WriteAllText(JsonFilePath, jsonText);
        }

        public void Save(string name, bool isAttend, string reason)
        {
            Participant participant; 
            if (Participants.Count > 0)
            {
                participant = Get(name);
                if (participant != null)
                {
                    Delete(name);
                }
            }
            participant = new Participant(name, isAttend, reason);
            Participants.Add(participant);
            Commit();
        }

        public void Delete(string name)
        {
            var participant = Get(name);
            Participants.Remove(participant);
            Commit();
        }


    }
}
