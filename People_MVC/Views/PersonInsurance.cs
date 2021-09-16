using People_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Views
{
    public class PersonInsurance
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
    }
}
