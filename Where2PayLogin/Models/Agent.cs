using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2PayLogin.Models
{
    public class Agent
    {
        //agent data
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public IList<AgentsBillers> AgentsBillers { get; set; } = new List<AgentsBillers>();
    }
}
