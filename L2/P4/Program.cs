using System;
using System.IO;
using System.Net;
using WebServer.Controllers;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string port = "8881";
            string serverFolder = "C:\\Users\\Administrator\\source\\repos\\coursesAsp\\L2\\P4\\sites\\";
            var server = new SuperWebServer();
            server.StartWork(port, serverFolder);
            server.Dispose();
            Console.ReadLine();
        }
    }



    class SuperWebServer : IDisposable
    {
        private HttpListener listner;
        public void StartWork(string port, string rootDirectory)
        {
            HttpListener listner = new HttpListener();
            listner.Prefixes.Add("http://*:" + port + "/");
            listner.Start();
            Console.WriteLine("Web Server wait connections on port:" + port);
            while (true)
            {
                HttpListenerContext context = listner.GetContext();
                HttpListenerRequest request = context.Request;
                if (request.Url.ToString().Contains("STOP"))
                {
                    listner.Stop();
                    Console.WriteLine("Stop listner");
                    break;
                }
                //HttpListenerResponse responce = context.Response;   
                RoutingUrl.Route(context,port, rootDirectory);
            }
        }

         public void Dispose()
        {
            this.listner.Close();
        }
    }






}
