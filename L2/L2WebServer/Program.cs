using System;
using System.IO;
using System.Net;
using WebServer.Controllers;
using WebServer.Infrastructure;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string port = "8881";
            ServiceLocator.RootDir = "C:\\Users\\Administrator\\source\\repos\\coursesAsp\\L2\\L2WebServer\\sites\\";
            ServiceLocator.ViewsDir = "C:\\Users\\Administrator\\source\\repos\\coursesAsp\\L2\\L2WebServer\\Views\\";
            ServiceLocator.Register<ILogger>(typeof(FileLogger));

            var server = new SuperWebServer();
            var logger = ServiceLocator.GetObjByType<ILogger>();

            server.StartWork(port,logger);
            server.Dispose();
            Console.ReadLine();
        }
    }



    class SuperWebServer : IDisposable
    {
        private HttpListener listner;
        public void StartWork(string port,ILogger logger)
        {
            HttpListener listner = new HttpListener();
            listner.Prefixes.Add("http://localhost:" + port + "/");
            listner.Start();
            logger.LogInfo($"Web Server wait connections on port: {port}");
            while (true)
            {
                HttpListenerContext context = listner.GetContext();
                HttpListenerRequest request = context.Request;
                if (request.Url.ToString().Contains("STOP"))
                {
                    listner.Stop();
                    Console.WriteLine("Stop listner");
                    logger.LogWarning("Webserver stop work by special command STOP");
                    break;
                } 
               RoutingUrl.Route(context,port,logger);
            }
        }

         public void Dispose()
        {
            this.listner.Close();
        }
    }






}
