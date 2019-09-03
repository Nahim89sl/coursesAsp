using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebServer.Controllers
{
    class IndexController : TemplateController
    {
        public override void ConstractPage(string siteFolder, HttpListenerContext context)
        {
            string filePath = siteFolder + "\\index.html";
            if (File.Exists(filePath))
            {
                Handle(context, File.ReadAllText(filePath));
            }
        }
        
        
    }
}
