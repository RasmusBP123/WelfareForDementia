using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DementiaWebsite.Models
{
    public class Person : IdentityUser
    {
        [Required]
        [Display(Name = "Email")]
        public string EMail { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

       /*[Display(Name = "Reenter Password")]
        [DataType(DataType.Password),Compare(nameof(PassWord))]
        public string ConfirmPassWord { get; set; }*/
    }
}
