using DAL.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemberShip.ViewModels
{
    public class RegistrationVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Username is required"),
            StringLength(200, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 200 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required"), 
            StringLength(200, ErrorMessage = "Email must be at most 200 characters"), 
            EmailAddress(ErrorMessage = "Invalid email address")]
        [Remote("CheckEmailExists", "Account", ErrorMessage = "This Email already registerd")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string IDNo { get; set; }
        public Gender Gender { get; set; }
        public string ParentPhone { get; set; }
        public bool IsEnabled { get; set; }
    }
}
