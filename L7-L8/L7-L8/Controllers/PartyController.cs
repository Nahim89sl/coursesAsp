using L7_L8.Models;
using L7_L8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L7_L8.Controllers
{
    public class PartyController : Controller
    {
        // GET: Party
        public IDataService DataService { get; set; }
        public PartyController(IDataService dataService)
        {
            DataService = dataService;
        }
        public ActionResult Index(int id)
        {
            Party party = DataService.GetParty(id);
            MemoriseParty(party);
            return View("index", party);
        }

        public ActionResult NewParty()
        {
            return View("New");
        }
        [HttpPost]
        public ActionResult New(string nameParty,string placeParty,string dateParty)
        {
            Party party = DataService.AddParty(new Party { IdParty = 0, NameParty = nameParty, PlaceParty = placeParty, DateParty = dateParty });
            return View("Party",party);
        }

        private void MemoriseParty(Party party)
        {
            if (Session["last_viewed_parties"] is Queue<int> lastParties)
            {
                if (!lastParties.Contains(party.IdParty))
                {
                    if (lastParties.Count >= 5)
                        lastParties.Dequeue();

                    lastParties.Enqueue(party.IdParty);
                    Session["last_viewed_parties"] = lastParties;
                }
            }
            else
            {
                lastParties = new Queue<int>();
                lastParties.Enqueue(party.IdParty);
                Session["last_viewed_parties"] = lastParties;
            }
        }

        [ChildActionOnly]
        public ActionResult LastParties ()
        {
            if (Session["last_viewed_parties"] is Queue<int> lastParties)
            {
                var parties = new List<Party>();
                foreach (var id in lastParties)
                {
                    parties.Add(DataService.GetParty(id));
                }
                return PartialView("_LastParty", parties);
            }

            return PartialView("_LastParty", new List<Party>());
        }




    }
}