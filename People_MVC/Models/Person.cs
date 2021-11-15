using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace People_MVC.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

         public string Name { get; set; }

        public string TeleNumber { get; set; }
        
        public int CityId { get; set; } 
        public City City { get; set; }   //one to one

       
       
        public List<PersonLanguage> PersonLanguages { get; set; }  //one to many
       

    }
}

