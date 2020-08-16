using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShip.ViewModels
{
    public class LoginVM
    {
        public string ReturnUrl { get; internal set; }

        [Required(ErrorMessage = "UserName is Required")]
        public string UserEmail { get; set; }

        [Required,
            DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
