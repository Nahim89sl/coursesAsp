using L4_P1_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4_P1_5.ViewModel
{
    public class ParticipantView
    {
        public Participant User { get; set; }
        public ParticipantView(Participant user)
        {
            User = user;
        }
    }
}