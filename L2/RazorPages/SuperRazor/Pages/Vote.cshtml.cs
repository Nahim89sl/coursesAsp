using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperRazor.DAL;

namespace SuperRazor.Pages
{
    public class VoteModel : PageModel
    {
        public IParticipantRepository Repository { set; get; }
        public VoteModel(IParticipantRepository repository)
        {
            Repository = repository;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost(string name, string attend)
        {
            if (!string.IsNullOrEmpty(name) && attend == "on")
            {
                Repository.Add(new Participant(name));

                return new RedirectToPageResult("/Participants");
            }

            return new RedirectToPageResult("/Vote");
        }
    }
}