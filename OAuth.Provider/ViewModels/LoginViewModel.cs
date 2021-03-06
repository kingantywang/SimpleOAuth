﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OAuth.Provider.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(18)]
        public string Name { get; set; }
        [Required]
        [StringLength(12,MinimumLength=6)]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}