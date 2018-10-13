using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DementiaWebsite.Models
{
    public class Person
    {
        public long ID { get; set; }
        private string _key { get; set; }
        public string Key {
            get
            {
                if(_key == null)
                {
                    _key = Regex.Replace(FirstName.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value;}
        }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
