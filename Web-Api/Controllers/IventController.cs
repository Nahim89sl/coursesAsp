using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api.DAL;
using Web_Api.Services;

namespace Web_Api.Controllers
{
    public class IventController : ApiController
    {
        public IDataService DataServ { get; set; }
        //public IventController(){}
        public IventController()
        {
            DataServ = new DataService(dataWorker: new SqlLiteProvider());
        }


        [HttpGet]
        public string Index()
        {
            return "This is the api version 1.0";
        }

        // GET: api/Ivent
        [HttpGet]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(DataServ.GetParties());
        }

        // GET: api/Ivent/5
        [HttpGet]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(DataServ.GetParty(id));
        }

        // POST: api/Ivent
        [HttpPost]
        public string Add([FromBody]string value)
        {
            return "value";
        }

        // DELETE: api/Ivent/5
        //[HttpDelete]
       
        public string Delete(int id)
        {
            var res = JsonConvert.SerializeObject(DataServ.DelParty(id));
            if (res == "ok")
            {
                return $"Ivent #{id} was deleted";
            }
            return $"Some problem with deleting";
        }
    }
}
