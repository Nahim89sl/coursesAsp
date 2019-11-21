using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Models
{
    public class Participant
    {
        public int IdParticipant { get; set; }
        public string NameParticipant { get; set; }
        public int AgeParticipant { get; set; }
        public string AvatarParticipant { get; set; }
        public int PartyId { get; set; }
    }
}