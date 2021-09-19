using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
