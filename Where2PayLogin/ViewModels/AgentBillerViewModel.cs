using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2PayLogin.Models;

namespace Where2PayLogin.ViewModels
{
    public class AgentBillerViewModel
    {
        public Agent Agent { get; set; }
        public List<SelectListItem> AvailableBillers { get; set; }

        public int BillerID { get; set; }
        public int AgentID { get; set; }

        public AgentBillerViewModel() { }

        public AgentBillerViewModel(Agent agent, IEnumerable<Biller> billers)
        {
            AvailableBillers = new List<SelectListItem>();

            foreach (var biller in billers)
            {
                AvailableBillers.Add(new SelectListItem
                {
                    Value = biller.ID.ToString(),//TOSTRING, BECAUSE ID IS AN INT
                    Text = biller.Name
                });
            }
            Agent = agent;
        }
    }
}
