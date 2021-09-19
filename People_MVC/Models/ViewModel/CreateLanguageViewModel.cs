using People_MVC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.ViewModel
{
    public class CreateLanguageViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Fill out language's name!")]
        [RegularExpression(@"[A-zöåäÅÖÄ]*", ErrorMessage = "Use only alphabets.")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
        
        //public List<Language> Languages { get; set; }
    }
}
