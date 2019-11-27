using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Auth.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", ErrorMessage = "Your password does not match") ]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}