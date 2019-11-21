using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Models
{
    public class Party
    {
        public int IdParty { get; set; }
        public string NameParty { get; set; }
        public string PlaceParty { get; set; }
        public string DateParty { get; set; }
    }
}