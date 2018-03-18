using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2PayLogin.Models
{
    public class AddUserBiller
    {
        public int ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }
        public int BillerID { get; set; }
        public Biller Biller { get; set; }
    }
}
