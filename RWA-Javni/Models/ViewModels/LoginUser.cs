using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_Javni.Models.ViewModels
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Username can't be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}