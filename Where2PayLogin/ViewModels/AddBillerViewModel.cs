using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Where2PayLogin.ViewModels
{
    public class AddBillerViewModel
    {
        [Required(ErrorMessage = "All Billers must have a name")]
        [Display(Name = "Biller Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Billers must provide a public phone number")]
        [Display(Name = "Biller's Customer Service Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Billers must provide a public email")]
        [Display(Name = "Biller Customer Service Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Billers must provide a website")]
        [Display(Name = "Biller Website")]
        public string Web { get; set; }
    }
}
