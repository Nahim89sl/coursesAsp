using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebServer.Infrastructure
{
    class FileLogger : ILogger
    {
        private string LogFilePath { get; }

        public FileLogger(string rootDir)
        {
            LogFilePath = rootDir +"log.txt";
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
            File.AppendAllText(LogFilePath, $"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} INFO: {message}{Environment.NewLine}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
            File.AppendAllText(LogFilePath, $"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} ERROR: {message}{Environment.NewLine}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
            File.AppendAllText(LogFilePath, $"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} WARNING: {message}{Environment.NewLine}");
        }
    }
}
