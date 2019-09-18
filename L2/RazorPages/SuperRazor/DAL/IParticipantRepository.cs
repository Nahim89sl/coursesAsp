using System.Collections.Generic;

namespace SuperRazor.DAL
{
    public interface IParticipantRepository
    {
        void Add(Participant participant);
        List<Participant> GetAll();
    }
}