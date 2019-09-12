using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer.DAL;
using WebServer.Model;

namespace WebServer.Logic
{
    class ParticipantsService : IParticipantsService
    {
        private IParticipantRepository Repository { get; } 

        public ParticipantsService(ParticipantRepository repository)
        {
            Repository = repository;
        }
        public List<Participant> ListAll()
        {
           return Repository.List();
        }

        public List<Participant> ListAttendent()
        {
            return Repository.List().Where(x => x.IsAttend).ToList();
        }

        public List<Participant> ListMissed()
        {
            return Repository.List().Where(x => !x.IsAttend).ToList();
        }

        public void Vote(string name, bool isAttend, string reason)
        {
            Repository.Save(name, isAttend, reason);
        }
    }
}
