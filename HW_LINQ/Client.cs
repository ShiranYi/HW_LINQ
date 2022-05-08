using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_LINQ
{
    internal class Client
    {
        public string Name { get; set; }
        public string HandleAgent { get; set; }


        public Client(string name, string handleAgent)
        {
            Name = name;
            HandleAgent = handleAgent;
        }
    }
        
}
