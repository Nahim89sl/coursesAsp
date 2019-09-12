using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebServer.Controllers
{
    class ErrorPage
    {
        public string ErrorPagePath;
        public ErrorPage(string ViewsDir)
        {
            ErrorPagePath = ViewsDir+"UnexistPage.html";
        }

        public string Show()
        {
            return File.ReadAllText(ErrorPagePath);
        }
    }
}
