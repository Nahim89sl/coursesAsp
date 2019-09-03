using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebServer.Controllers
{
    abstract class TemplateController
    {
        abstract public void ConstractPage(string siteFolder, HttpListenerContext context);

        public static void Handle(HttpListenerContext context, string pageText)
        {
            HttpListenerResponse responce = context.Response;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(pageText);
            responce.ContentLength64 = buffer.Length;
            Stream output = responce.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

    }
}
