using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using WebServer.DAL;
using WebServer.Logic;
using WebServer.Model;

namespace WebServer.Controllers
{
    class VoteController : TemplateController
    {
        private HttpListenerRequest Request { get; }
        private IParticipantsService PartService { get; }
        public VoteController(HttpListenerRequest request, IParticipantsService partService)
        {
            Request = request;
            PartService = partService;
        }
        public override string ConstractPage(string siteFolder)
        {
            string guestName = "";
            bool visitParty = false;
            string reason = "";
            string pageText = "";
            if (Request.HttpMethod == "POST")
            {
                System.IO.Stream body = Request.InputStream;
                System.Text.Encoding encoding = Request.ContentEncoding;
                System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                string postParams = reader.ReadToEnd();
                var requestParams = HttpUtility.ParseQueryString(postParams);
                guestName = requestParams.Get("participant");
                reason = requestParams.Get("reason");
                if (requestParams.Get("visitParty") == "true")
                {
                    visitParty = true;
                }
                PartService.Vote(guestName, visitParty, reason);
            }

            pageText = File.ReadAllText(siteFolder + "vote.html");
            return pageText;
        }
    }
}
