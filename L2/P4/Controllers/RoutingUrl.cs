using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WebServer.Controllers
{
    class RoutingUrl
    {

        public static void Route(HttpListenerContext context, string port, string rootFolder)
        {

            //check site exist
            var url = context.Request.Url.ToString();
            Regex siteRgx = new Regex("(?<=:" + port + "/).*?(?=/)");
            Match match = siteRgx.Match(url);


            string siteName = match.Value;
            string siteFolder = rootFolder + siteName;

            if (Directory.Exists(siteFolder))
            {
                Console.WriteLine($"site: {siteName}");
                //try find file from request
                if (url.Contains("index.html"))
                {
                    var indexPage = new IndexController();
                    indexPage.ConstractPage(siteFolder, context);
                }
                else if (url.Contains("void"))
                {
                    var voisas = new VoteController();
                    voisas.ConstractPage(siteFolder, context);
                }
                else if (url.Contains("participants.html"))
                {
                    var partis = new ParticipantsController();
                    partis.ConstractPage(siteFolder, context);
                }
                else//unexist page
                {
                    Console.WriteLine("Unknown page");
                }
            }
            else
            {
                Console.WriteLine("Unknown site");
            }
        }
    }
}
