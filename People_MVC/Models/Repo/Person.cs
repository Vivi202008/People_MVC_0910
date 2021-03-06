using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"[A-z]*", ErrorMessage = "Use only alphabets.")]
        public string City { get; set; }

        [Required(ErrorMessage = "You need to fill out name field!")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Please input only numbers. ")]
        [StringLength(20, MinimumLength = 8)]
        public string TeleNumber { get; set; }
    }
}
