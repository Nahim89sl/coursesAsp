using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace WebServer
{
    public class FileWorker
    {
        private static string ErrorNotFindSite = "<html><head><title>Site ## not exist </title> <meta charset='utf8'></head><body>Sorry! We can't find web-site ## </body></html>";
        private static string ErrorNotFindPage = "<html><head><title>Page ## not finded </title> <meta charset='utf8'></head><body>Maybe page ## not exist on this site</body></html>";
        private static string ErrorwrongRequest = "<html><head><title>WrongRequest</title> <meta charset='utf8'></head><body>Your request is ##<br>Try check it</body></html>";
        private static string portSrv;
        private static string webSrvFolder;

        public FileWorker(string port,string serverFolder)
        {
            portSrv = port;
            webSrvFolder = serverFolder;
        }



        public string AnswerToRequest(string request)
        {
            //try find site name
            Console.WriteLine($"Request: {request}");
            Regex siteRgx = new Regex("(?<=:"+ portSrv + "/).*?(?=/)");
            Match match = siteRgx.Match(request);
            if(match.Success)
            {
                string siteName = match.Value;
                if(Directory.Exists(webSrvFolder+siteName))
                {
                    Console.WriteLine($"site: {siteName}");
                    //try find file from request
                    Regex fileRgx = new Regex("(?<="+ siteName+ "/).*");
                    match = fileRgx.Match(request);
                    string filePath;
                    if (match.Success)
                    {
                        filePath = webSrvFolder + siteName + "\\" + match.Value;
                        Console.WriteLine($"File name: {match.Value}");
                    }
                    else
                    {
                        filePath = webSrvFolder + siteName + "\\index.html";
                    }
                    
                    //try find file on server
                    if (File.Exists(filePath))
                    {
                        Console.WriteLine($"Return answer");
                        string fileContent = File.ReadAllText(filePath);
                        //dinaminc load json 
                        if(filePath.Contains("participants.html"))
                        {
                            string jsonString = File.ReadAllText(webSrvFolder + siteName + "\\wwwroot\\json");
                            var users = JsonConvert.DeserializeObject<List<Participant>>(jsonString);
                            string userListTopage = "";
                            foreach(var guest in users)
                            {
                                userListTopage += "<li>" + guest.guest+ "</li>";
                            }
                            fileContent = fileContent.Replace("{prticipants}", userListTopage); 
                        }


                        return fileContent;
                    }
                    else
                    {
                        Console.WriteLine($"Page not find: {match.Value}");
                        return ErrorNotFindPage.Replace("##", match.Value);
                    }
                }
                else
                {
                    Console.WriteLine($"Site {siteName} not finded");
                    return ErrorNotFindSite.Replace("##", siteName);
                }
            }
            else
            {
                Console.WriteLine($"Wrong request {request}");
                return ErrorwrongRequest.Replace("##", request);
            }
        }
    }
}
