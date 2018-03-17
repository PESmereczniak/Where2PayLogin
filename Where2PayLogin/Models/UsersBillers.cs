using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2PayLogin.Models
{
    public class UsersBillers
    {
        public int ApplicationUserID { get; set; }
        public ApplicationUser User { get; set; }
        public int UserBillerInfoID { get; set; }
        public UsersBillerInfo UsersBillerInfo { get; set; }
    }
}
