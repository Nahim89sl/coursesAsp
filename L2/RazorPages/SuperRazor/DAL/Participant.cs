using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperRazor.DAL
{
    public class Participant
    {
        public string Name { get; set; }

        public Participant(string name)
        {
            Name = name;
        }
    }
}
