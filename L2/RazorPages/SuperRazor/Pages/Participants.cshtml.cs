using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperRazor.DAL;

namespace SuperRazor.Pages
{
    public class ParticipantsModel : PageModel
    {
        public List<Participant> Participants { get; set; }
        public ParticipantsModel(IParticipantRepository participantRepo)
        {
            Participants = participantRepo.GetAll();
        }
        public void OnGet()
        {

        }
    }
}