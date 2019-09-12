using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebServer.Controllers
{
    class ErrorSite
    {
        public string ErrorPagePath;
        public ErrorSite(string ViewsDir)
        {
            ErrorPagePath = ViewsDir + "UnexistSite.html";
        }

        public string Show()
        {
            return File.ReadAllText(ErrorPagePath);
        }
    }
}
