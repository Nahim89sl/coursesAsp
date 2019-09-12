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
        abstract public string ConstractPage(string siteFolder);
    }
}
