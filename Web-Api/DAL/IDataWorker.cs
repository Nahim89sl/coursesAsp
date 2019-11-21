using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api.Models;

namespace Web_Api.DAL
{
    public interface IDataWorker
    {
        //party operations
        Party GetParty(int id);
        List<Party> GetParties();
        Party AddParty(Party party);
        string DelParty(int id);
        string EditParty(Party party);
        List<Participant> GetPartyParticipant(Party party);

        //participant operations
        List<Participant> GetParticipants();
        Participant GetParticipant(int id);
        Participant AddParticipant(Participant participant);
        string DelParticipant(Participant participant);
        string EditParticipant(Participant participant);

    }
}
