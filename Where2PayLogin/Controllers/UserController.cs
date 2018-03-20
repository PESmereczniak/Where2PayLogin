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
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;

        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult Index()
        {
            //WILL NEED TO LIMIT INFO DISPLAYED TO CURRENT, LOGGED IN USER
            //MAYBE DONE IN VIEW MODEL?
            //usersBillers = usersBillerInfo
            //where (usersBillerInfo.UserId == thisUser.ID)

            List<UsersBillerInfo> usersBillerInfo = context.UsersBillerInfo.ToList();
            return View(usersBillerInfo);
        }

        public UserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }
        
        //public UserController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //render add user's biller page
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var user = await _userManager.GetUserAsync(User);
            List<Biller> billers = context.Billers.ToList();
            //var UserID = user.Id;
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return View(new AddUsersBillerViewModel(user, billers));
        }

        // GET: /<controller>/
        //[HttpPost]
        //public IActionResult Add(AddUsersBillerViewModel addUsersBillerViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UsersBillerInfo newUsersBillerInfo = new UsersBillerInfo
        //        {
        //            UserId = addUsersBillerViewModel.UserId,
        //            BillerID = addUsersBillerViewModel.BillerID.ToString(),
        //            BillerDescription = addUsersBillerViewModel.BillerDescription,
        //            UsersAccountNumber = addUsersBillerViewModel.UsersAccountNumber
        //        };

        //        //creates model in database
        //        context.UsersBillerInfo.Add(newUsersBillerInfo);
        //        //commits changes to db
        //        context.SaveChanges();

        //        return Redirect("/User/Index");
        //    }
        //    return View(addUsersBillerViewModel);
        //}

        //VIEW BILLER FUNCTIONS NOT NECESSARY IN THIS CONTEXT
        //MAY BE ABLE TO USE SOME OF CODE FOR USER BILLER INDEX?
        //public IActionResult ViewBiller(int id)
        //{
        //    Biller biller = context.Billers.Single(b => b.ID == id);

        //    List<AgentsBillers> billersAgents = context
        //        .AgentsBillers
        //        .Include(billersAgent => billersAgent.Agent)
        //        .Where(ba => ba.BillerID == id)
        //        .ToList();

        //    ViewBillerViewModel viewModel = new ViewBillerViewModel
        //    {
        //        Biller = biller,
        //        Agents = billersAgents
        //    };

        //    return View(viewModel);
        //}

        //CREATE USER REMOVAL LATER - NOT NECESSARY FOR CURRENT DEMONSTRATION
        //public IActionResult Remove()
        //{
        //    ViewBag.title = "Remove User";
        //    ViewBag.billers = context.ApplicationUsers.ToList();

        //    return View();
        //}

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
