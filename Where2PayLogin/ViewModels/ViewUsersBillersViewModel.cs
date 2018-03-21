using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2PayLogin.Models;

namespace Where2PayLogin.ViewModels
{
    public class ViewUsersBillersViewModel
    {
        public ApplicationUser User { get; set; }
        public IList<UsersBillerInfo> UsersBillerInfo { get; set; }
        public IList<Biller> Billers { get; set; }

        public ViewUsersBillersViewModel() { }

        public ViewUsersBillersViewModel(ApplicationUser user, IList<UsersBillerInfo> usersBillerInfo, IList<Biller> billers)
        {
            User = user;
            UsersBillerInfo = usersBillerInfo;
            Billers = billers;
        }
    }
}

