using People_MVC.Models.ViewModel;
using People_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    interface ICountryService
    {
        Country Add(CreateCountryViewModel country);

        CountryViewModel All();
        CountryViewModel FindBy(CountryViewModel search);
        Country FindBy(int id);

        bool Remove(int id);
    }
}
