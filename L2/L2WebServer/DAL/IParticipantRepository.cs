using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer.Model;

namespace WebServer.DAL
{
    interface IParticipantRepository
    {
        List<Participant> List();
        Participant Get(string name);
        void Commit();
        void Save(string name, bool isAttend, string reason);
        void Delete(string name);

    }
}
