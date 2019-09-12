using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer.Model;

namespace WebServer.Logic
{
    interface IParticipantsService
    {
        void Vote(string name, bool isAttend, string reason);
        List<Participant> ListAll();
        List<Participant> ListAttendent();
        List<Participant> ListMissed();
    }
}
