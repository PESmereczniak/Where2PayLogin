using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2PayLogin.Models;

namespace Where2PayLogin.ViewModels
{
    public class AddAgentViewModel
    {
        [Required(ErrorMessage = "All Agent Locations must have a name")]
        [Display(Name = "Agent Location (DBA) Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Public Contact Phone Number is Required")]
        [Display(Name = "Public Contact Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Street Address is Required")]
        [Display(Name = "Street Address")]
        public string Street1 { get; set; }

        [Display(Name = "Street 2")]
        public string Street2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code is Required")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
    }
}
