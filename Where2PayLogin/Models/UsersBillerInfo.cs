using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Where2PayLogin.Models
{
    public class UsersBillerInfo
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int BillerID { get; set; }
        public string BillerName { get; set; }
        public string BillerDescription { get; set; }
        public string UsersAccountNumber { get; set; }
    }
}
