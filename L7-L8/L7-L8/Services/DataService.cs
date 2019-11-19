using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using L7_L8.DAL;
using L7_L8.Models;

namespace L7_L8.Services
{
    public class DataService : IDataService
    {
        public IDataRepository DataRepository { set; get; }
        public DataService(IDataRepository dataRepository)
        {
            DataRepository = dataRepository;
        }
        public List<Participant> GetAllParticipants()
        {
            return DataRepository.GetParticipants();
        }

        public List<Party> GetAllParties()
        {
            return DataRepository.GetParties();
        }

        public Participant GetParticipant()
        {
            return DataRepository.GetParticipant(1);
        }

        public Party GetParty(int id)
        {
            return DataRepository.GetParty(id);
        }

        public Party AddParty(Party party)
        {
            return DataRepository.AddParty(party);
        }
    }
}