using L4_P1_5.DAL;
using L4_P1_5.Infrastructure;
using L4_P1_5.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L4_P1_5.Controllers
{
    public class ParticipantController : Controller
    {
        // GET: Participant
        private IParticipantsRepository ParticipantsRepository { get; }
        private ILogger Logger { get; }

        public ParticipantController(IParticipantsRepository participantsRepository, ILogger logger)
        {
            ParticipantsRepository = participantsRepository;
            Logger = logger;
        }
        public ActionResult Index(string name)
        {            
             var participant = ParticipantsRepository.GetUser(name);
             return View(participant);

        }
        [HttpPost]
        public ActionResult UploadAva(string userName,HttpPostedFileBase avaFile)
        {
            string filename = System.IO.Path.GetFileName(avaFile.FileName);
            if(filename!=null)
            {
                avaFile.SaveAs(Server.MapPath("~/Images/users/ava_"+filename));
                var user = ParticipantsRepository.GetUser(userName);
                ParticipantsRepository.Save(user.PartyId, user.Name, user.IsAttend, "ava_" + filename);
            }
            return RedirectToAction("Index", "Participant",new { name = userName });
        }
    }
}