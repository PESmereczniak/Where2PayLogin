﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Where2PayLogin.Models;

namespace Where2PayLogin.ViewModels
{
    public class ViewBillerViewModel
    {
        public Biller Biller { get; set; }
        public IList<AgentsBillers> Agents { get; set; }
    }
}