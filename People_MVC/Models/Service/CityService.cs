using People_MVC.Models.Repo;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    public class CityService : ICityService
    {
        public ICityRepo _cityRepo;
        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public City Add(CreateCityViewModel city)
        {
            return _cityRepo.Create(city); ;
        }

        public CityViewModel All()
        {
            CityViewModel cityViewModel = new CityViewModel
            {
                Cities = _cityRepo.Read()
            };
            return cityViewModel;
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public CityViewModel FindBy(CityViewModel search)
        {
            search.Cities = _cityRepo.Read().FindAll(city => city.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase));
            return search;
        }

        public bool Remove(int id)
        {
            City city = FindBy(id);
            return _cityRepo.Delete(city);
        }
    }
}
