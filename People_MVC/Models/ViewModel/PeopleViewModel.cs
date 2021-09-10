using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace People_MVC.Models.ViewModel
{
    public class PeopleViewModel
    {
        [Required(ErrorMessage = "You need to fill out city field!")]
        [RegularExpression(@"[A-z]*", ErrorMessage = "Use only alphabets.")]
        [MaxLength(50),MinLength(2)]
        public string Search { get; set; }

        public List<Person> PeopleList { get; set; }

    }
}
