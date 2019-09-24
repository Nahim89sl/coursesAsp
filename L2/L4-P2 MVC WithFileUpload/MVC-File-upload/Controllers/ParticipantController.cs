using L4_P1_5.DAL;
using L4_P1_5.Infrastructure;
using L4_P1_5.Logic;
using L4_P1_5.ViewModel;
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
        private IParticipantsRepository ParticipantsService { get; }
        private ILogger Logger { get; }

        public ParticipantController(IParticipantsRepository participantsRepository, ILogger logger)
        {
            ParticipantsService = participantsRepository;
            Logger = logger;
        }



        public ActionResult Index()
        {
            if (RouteData.Values["name"] != null)
            {
                var participant = ParticipantsService.Get(RouteData.Values["name"].ToString());

                var vi = new ParticipantView (participant);
                return View(participant);

            }
            return View();
        }

        



    }
}