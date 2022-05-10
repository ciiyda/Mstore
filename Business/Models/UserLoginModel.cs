﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="{0} is required!")]
        [MinLength(3,ErrorMessage = "{0} must be minimum {1} characters ")]
        [MaxLength(30,ErrorMessage = "{0} must be maximum {1} characters ")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(3, ErrorMessage = "{0} must be minimum {1} characters ")]
        [MaxLength(30, ErrorMessage = "{0} must be maximum {1} characters ")]
        public string Password { get; set; }


    }
}
