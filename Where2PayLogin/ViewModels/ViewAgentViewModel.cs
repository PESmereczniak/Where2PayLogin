using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2PayLogin.Models;

namespace Where2PayLogin.ViewModels
{
    public class ViewAgentViewModel
    {
        public Agent Agent { get; set; }
        public IList<AgentsBillers> Billers { get; set; }
    }
}
