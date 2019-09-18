using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SuperRazor.DAL
{
    public class ParticipantRepository : IParticipantRepository
    {
        private List<Participant> Participants { get; set; }

        public ParticipantRepository()
        {
            var json = File.ReadAllText("data.json");
            Participants = JsonConvert.DeserializeObject<List<Participant>>(json);
        }

        public List<Participant> GetAll()
        {
            return Participants;
        }

        public void Add(Participant participant)
        {
            Participants.Add(participant);

            var json = JsonConvert.SerializeObject(Participants);
            File.WriteAllText("data.json", json);
        }
    }
}

