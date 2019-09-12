using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServer.Infrastructure
{
    interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);

    }
}
