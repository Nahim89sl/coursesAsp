using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WebServer.DAL;
using WebServer.Logic;
using WebServer.Model;

namespace WebServer.Controllers
{
    class ParticipantsController : TemplateController
    {
        private IParticipantsService PartService { get; }
        public ParticipantsController(IParticipantsService partService)
        {
            PartService = partService;
        }
        public override string ConstractPage(string siteFolder)
        {
            string filePath = siteFolder + "\\participants.html";
            string pageText = "err";
            if (File.Exists(filePath))
            {
                string htmlList = "";
                pageText = File.ReadAllText(filePath);
                var participants = PartService.ListAttendent();
                if (participants != null)
                {
                    foreach (var user in participants)
                    {
                        htmlList += $"<li>{user.Name}</li>";
                    }
                }
                pageText = pageText.Replace("{participants}", htmlList);
            }
            return pageText;
        }
    }
}
