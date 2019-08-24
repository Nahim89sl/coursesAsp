using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string port = "8881";
            string serverFolder = "C:\\Users\\Administrator\\source\\repos\\coursesAsp\\L2\\sites\\";

            FileWorker fileAnswer = new FileWorker(port, serverFolder);

            HttpListener listner = new HttpListener();
            listner.Prefixes.Add("http://*:"+port+"/");
            listner.Start();
            Console.WriteLine("Web Server wait connections on port:"+port);
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
                HttpListenerResponse responce = context.Response;//wait request

                string responceStr = fileAnswer.AnswerToRequest(request.Url.ToString());
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responceStr);
                responce.ContentLength64 = buffer.Length;
                Stream output = responce.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            Console.ReadLine();
        }
    }
}
