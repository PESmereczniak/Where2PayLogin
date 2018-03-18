using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2PayLogin.Models;

namespace Where2PayLogin.ViewModels
{
    public class AddUsersBillerViewModel
    {
        public ApplicationUser User { get; set; }
        public List<SelectListItem> AvailableBillers { get; set; }

        public int BillerID { get; set; }
        public int UserId { get; set; }

        public AddUsersBillerViewModel() { }

        public AddUsersBillerViewModel(ApplicationUser user, IEnumerable<Biller> billers)
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
            User = user;
        }

        [Required(ErrorMessage = "Please Enter a Description of the Account")]
        [Display(Name = "Description: ")]
        public string BillerDescription { get; set; }

        [Required(ErrorMessage = "Account Number is required")]
        [Display(Name = "Account Number: ")]
        public string UsersAccountNumber { get; set; }

        public string UserID { get; set; }
    }
}
