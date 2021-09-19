using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    interface ICityService
    {
        public City Add(CreateCityViewModel city);

        public CityViewModel All();
        public City FindBy(int id);
        public CityViewModel FindBy(CityViewModel search);

        public bool Remove(int id);
    }
}
