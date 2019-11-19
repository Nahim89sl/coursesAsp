using L7_L8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_L8.Services
{
    public interface IDataService
    {
        List<Party> GetAllParties();
        Party GetParty(int id);
        Participant GetParticipant();
        List<Participant> GetAllParticipants();

        Party AddParty(Party party);

    }
}
