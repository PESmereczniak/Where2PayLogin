using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2PayLogin.Models
{
    public class AgentsBillers
    {
        public int AgentID { get; set; }
        public Agent Agent { get; set; }

        public int BillerID { get; set; }
        public Biller Biller { get; set; }
    }
}
