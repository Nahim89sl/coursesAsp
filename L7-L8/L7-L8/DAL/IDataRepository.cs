using L7_L8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7_L8.DAL
{
    public interface IDataRepository
    {
        List<Participant> GetParticipants();
        Participant GetParticipant(int id);
        List<Party> GetParties();

        Party GetParty(int id);
        Party AddParty(Party party);
    }
}
