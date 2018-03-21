using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Where2PayLogin.Data;
using Where2PayLogin.Models;
using Where2PayLogin.ViewModels;


namespace Where2PayLogin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;

        private readonly UserManager<ApplicationUser> _userManager;

        //VIEW INDIVIDUAL USER'S BILLER'S INFO
        //CURRENTLY SHOWS ALL USERS' BILLER'S INFO
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            List<UsersBillerInfo> usersBillers = context.UsersBillerInfo.ToList();
            List<Biller> billers = context.Billers.ToList();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return View(new ViewUsersBillersViewModel(user, usersBillers, billers));
        }

        public UserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        //RENDER add user's biller page
        public async Task<IActionResult> Add()
        {
            var user = await _userManager.GetUserAsync(User);
            List<Biller> billers = context.Billers.ToList();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return View(new AddUsersBillerViewModel(user, billers));
        }

        //SUBMIT add user's biller page
        [HttpPost]
        public IActionResult Add(AddUsersBillerViewModel addUsersBillerViewModel)
        {
            if (ModelState.IsValid)
            {
                UsersBillerInfo newUsersBillerInfo = new UsersBillerInfo
                {
                    UserId = addUsersBillerViewModel.UserID,
                    BillerName = addUsersBillerViewModel.BillerName,
                    BillerID = addUsersBillerViewModel.BillerID,
                    BillerDescription = addUsersBillerViewModel.BillerDescription,
                    UsersAccountNumber = addUsersBillerViewModel.UsersAccountNumber
                };

                //creates model in database
                context.UsersBillerInfo.Add(newUsersBillerInfo);
                //commits changes to db
                context.SaveChanges();

                return Redirect("/User/Index");
            }
            return View(addUsersBillerViewModel);
        }

        public IActionResult RemoveUsersBiller()
        {
            ViewBag.title = "Remove Biller";
            ViewBag.billers = context.UsersBillerInfo.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult RemoveUsersBiller(int[] usersBillerIds)
        {
            foreach (int usersBillerId in usersBillerIds)
            {
                UsersBillerInfo removeUsersBiller = context.UsersBillerInfo.Single(ub => ub.ID == usersBillerId);
                context.UsersBillerInfo.Remove(removeUsersBiller);
            }

            context.SaveChanges();

            return Redirect("/User/Index");
        }

        //ADMIN LEVEL VIEW USERS (C/P FROM VIEW AGENT)
        //public IActionResult ViewAgent(int id)
        //{
        //    List<AgentsBillers> agentsBillers = context
        //        .AgentsBillers
        //        .Include(agentsBiller => agentsBiller.Biller)
        //        .Where(ab => ab.AgentID == id)
        //        .ToList();

        //    Agent agent = context.Agents.Single(a => a.ID == id);

        //    ViewAgentViewModel viewModel = new ViewAgentViewModel
        //    {
        //        Agent = agent,
        //        Billers = agentsBillers
        //    };

        //    return View(viewModel);
        //}

        //ADMIN LEVEL USER REMOVAL - PAGE RENDER
        //public IActionResult Remove()
        //{
        //    ViewBag.title = "Remove User";
        //    ViewBag.billers = context.ApplicationUsers.ToList();

        //    return View();
        //}

        //ADMIN LEVEL USER REMOVAL - REMOVAL FUNCTIONS
        //[HttpPost]
        //public IActionResult Remove(int[] userIds)
        //{
        //    foreach (int userId in userIds)
        //    {
        //        ApplicationUser user = context.ApplicationUsers.Single(u => u.ID == userId);
        //        context.ApplicationUsers.Remove(user);
        //    }

        //    context.SaveChanges();

        //    return Redirect("/User/Index");
        //}
    }
}
