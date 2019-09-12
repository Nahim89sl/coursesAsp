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
        public override string ConstractPage(string siteFolder)
        {
            string filePath = siteFolder + "\\index.html";
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return "err";
        } 
    }
}
