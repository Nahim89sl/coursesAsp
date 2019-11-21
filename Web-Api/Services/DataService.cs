using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api.DAL;
using Web_Api.Models;

namespace Web_Api.Services
{
    public class DataService : IDataService
    {
        //SqlLiteProvider : IDataWorker
        public IDataWorker DataWorker { get; set; }
        public DataService(IDataWorker dataWorker)
        {
            DataWorker = dataWorker;
        }
        public Participant AddParticipant(Participant participant)
        {
            return DataWorker.AddParticipant(participant);
        }

        public Party AddParty(Party party)
        {
            return DataWorker.AddParty(party);
        }

        public string DelParticipant(Participant participant)
        {
            return DataWorker.DelParticipant(participant);
        }

        public string DelParty(int id)
        {
            return DataWorker.DelParty(id);
        }

        public string EditParticipant(Participant participant)
        {
            return DataWorker.EditParticipant(participant);
        }

        public string EditParty(Party party)
        {
            return DataWorker.EditParty(party);
        }

        public Participant GetParticipant(int id)
        {
            return DataWorker.GetParticipant(id);
        }

        public List<Participant> GetParticipants()
        {
            return DataWorker.GetParticipants();
        }

        public List<Party> GetParties()
        {
            return DataWorker.GetParties();
        }

        public Party GetParty(int id)
        {
            return DataWorker.GetParty(id);
        }

        public List<Participant> GetPartyParticipant(Party party)
        {
            return DataWorker.GetPartyParticipant(party);
        }
    }
}