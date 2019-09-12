using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using WebServer.DAL;
using WebServer.Infrastructure;
using WebServer.Logic;

namespace WebServer.Controllers
{
    class RoutingUrl
    {
        public static string SitePath { set; get; }

        public static void Route(HttpListenerContext context, string port, ILogger logger)
        {

            string pageText = "";
            var errorPage = new ErrorPage(ServiceLocator.ViewsDir);
            var errorSite = new ErrorSite(ServiceLocator.ViewsDir);

            //check site exist
            var url = context.Request.Url.ToString();
            Regex siteRgx = new Regex("(?<=:" + port + "/).*?(?=/)");
            Match match = siteRgx.Match(url);
            string siteFolder = "";
            if (match.Success)
            {
                logger.LogInfo($"try find site {match.Value} on server");

                siteFolder = ServiceLocator.RootDir + match.Value + "\\";

                if (Directory.Exists(siteFolder))
                {
                    Console.WriteLine($"site: {match.Value}");
                    //try find file from request
                    SitePath = siteFolder;
                    ServiceLocator.Register<IParticipantsService>(typeof(ParticipantsService));
                    var serviceRepository = ServiceLocator.GetObjByType<IParticipantsService>();

                    if (url.Contains("index.html"))
                    {
                        var indexPage = new IndexController();
                        pageText = indexPage.ConstractPage(siteFolder);
                    }
                    else if (url.Contains("void"))
                    {
                        var voisas = new VoteController(context.Request, serviceRepository);
                        pageText = voisas.ConstractPage(siteFolder);
                    }
                    else if (url.Contains("participants.html"))
                    {
                        var partis = new ParticipantsController(serviceRepository);
                        pageText = partis.ConstractPage(siteFolder);
                    }
                    else//unexist page
                    {
                        logger.LogError("Wromng page name");
                        pageText = errorPage.Show();
                    }
                }
                else
                {
                    logger.LogError($"Cant't find site {match.Value} on server");
                    pageText = errorSite.Show();
                }
            }
            else
            {
                logger.LogError($"Wromng Url format {url}");
                pageText = errorSite.Show();
            }

            HttpListenerResponse responce = context.Response;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(pageText);
            responce.ContentLength64 = buffer.Length;
            Stream output = responce.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
