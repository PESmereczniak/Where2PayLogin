using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Where2PayLogin.Data;
using Where2PayLogin.Models;
using Where2PayLogin.ViewModels;

namespace Where2PayLogin.Controllers
{
    [Authorize]
    public class BillerController : Controller
    {
        private readonly ApplicationDbContext context;

        public BillerController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Biller> billers = context.Billers.ToList();

            return View(billers);
        }

        public IActionResult Add()
        {
            AddBillerViewModel addBillerViewModel = new AddBillerViewModel();
            return View(addBillerViewModel);
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Add(AddBillerViewModel addBillerViewModel)
        {
            if (ModelState.IsValid)
            {
                Biller newBiller = new Biller
                {
                    Name = addBillerViewModel.Name,
                    Phone = addBillerViewModel.Phone,
                    Email = addBillerViewModel.Email,
                    Web = addBillerViewModel.Web
                };

                //creates model in database
                context.Billers.Add(newBiller);
                //commits changes to db
                context.SaveChanges();

                return Redirect("/Biller/Index");
            }
            return View(addBillerViewModel);
        }

        [AllowAnonymous]
        public IActionResult BillerList()
        {
            List<Biller> billers = context.Billers.ToList();

            return View(billers);
        }

        public IActionResult ViewBiller(int id)
        {
            Biller biller = context.Billers.Single(b => b.ID == id);

            List<AgentsBillers> billersAgents = context
                .AgentsBillers
                .Include(billersAgent => billersAgent.Agent)
                .Where(ba => ba.BillerID == id)
                .ToList();

            ViewBillerViewModel viewModel = new ViewBillerViewModel
            {
                Biller = biller,
                Agents = billersAgents
            };

            return View(viewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Billers";
            ViewBag.billers = context.Billers.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] billerIds)
        {
            foreach (int billerId in billerIds)
            {
                Biller theBiller = context.Billers.Single(c => c.ID == billerId);
                context.Billers.Remove(theBiller);
            }

            context.SaveChanges();

            return Redirect("/Biller");
        }
    }
}
