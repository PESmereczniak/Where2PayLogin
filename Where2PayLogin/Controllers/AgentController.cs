using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Where2PayLogin.Models;
using Where2PayLogin.ViewModels;
using Where2PayLogin.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Where2PayLogin.Controllers
{
    public class AgentController : Controller
    {
        private readonly ApplicationDbContext context;

        public AgentController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<Agent> agents = context.Agents.ToList();
            return View(agents);
        }

        public IActionResult Add()
        {
            AddAgentViewModel addAgentViewModel = new AddAgentViewModel();
            return View(addAgentViewModel);
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Add(AddAgentViewModel addAgentViewModel)
        {
            if (ModelState.IsValid)
            {
                Agent newAgent = new Agent
                {
                    Name = addAgentViewModel.Name,
                    Phone = addAgentViewModel.Phone,
                    Street1 = addAgentViewModel.Street1,
                    Street2 = addAgentViewModel.Street2,
                    City = addAgentViewModel.City,
                    State = addAgentViewModel.State,
                    Zip = addAgentViewModel.Zip
                };

                context.Agents.Add(newAgent);
                context.SaveChanges();

                return Redirect("/Agent");

            }
            return View(addAgentViewModel);
        }

        public IActionResult ViewAgent(int id)
        {
            List<AgentsBillers> agentsBillers = context
                .AgentsBillers
                .Include(agentsBiller => agentsBiller.Biller)
                .Where(ab => ab.AgentID == id)
                .ToList();

            Agent agent = context.Agents.Single(a => a.ID == id);

            ViewAgentViewModel viewModel = new ViewAgentViewModel
            {
                Agent = agent,
                Billers = agentsBillers
            };

            return View(viewModel);
        }

        public IActionResult AddAgentsBillers(int id)
        {
            Agent agent = context.Agents.Single(a => a.ID == id);
            List<Biller> billers = context.Billers.ToList();
            return View(new AgentBillerViewModel(agent, billers));
        }

        [HttpPost]
        public IActionResult AddAgentsBillers(AgentBillerViewModel agentBillerViewModel)
        {
            if (ModelState.IsValid)
            {
                var agentID = agentBillerViewModel.AgentID;
                var billerID = agentBillerViewModel.BillerID;

                IList<AgentsBillers> existingItems = context.AgentsBillers
    .Where(ab => ab.AgentID == agentID)
    .Where(ab => ab.BillerID == billerID).ToList();

                if (existingItems.Count == 0)
                {
                    AgentsBillers agentBiller = new AgentsBillers
                    {
                        Agent = context.Agents.Single(a => a.ID == agentID),
                        Biller = context.Billers.Single(b => b.ID == billerID)
                    };
                    context.AgentsBillers.Add(agentBiller);
                    context.SaveChanges();
                }

                return Redirect(string.Format("/Agent/ViewAgent/{0}", agentBillerViewModel.AgentID));
            }

            return View(agentBillerViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Agents";
            ViewBag.agents = context.Agents.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] agentIds)
        {
            foreach (int agentId in agentIds)
            {
                Agent removeCheese = context.Agents.Single(c => c.ID == agentId);
                context.Agents.Remove(removeCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
    }
}
