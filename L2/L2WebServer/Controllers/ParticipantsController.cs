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
            FileInfo fileInfo = new FileInfo(siteFolder + "\\data\\json");
            var time1 = fileInfo.LastWriteTime;

            FileInfo fileInfoCach = new FileInfo(siteFolder + "\\data\\participantsKach");
            var time2 = fileInfoCach.LastWriteTime;
            var time3 = DateTime.Now;


            if((time1 > time2) ||(time3.Minute - time2.Minute > 5))
            {
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
                    File.WriteAllText(siteFolder + "\\data\\participantsKach", pageText);
                }
            }
            else
            {
                pageText = File.ReadAllText(siteFolder + "\\data\\participantsKach");
            }

           
            return pageText;
        }
    }
}
