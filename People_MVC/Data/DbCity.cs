using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Data
{
    public class DbCity : ICityRepo
    {
        private readonly PeopleDbContext _dbPeopleC;
        
        public DbCity(PeopleDbContext peopleDbContext)
        {
            _dbPeopleC = peopleDbContext;
        }
        
        public City Create(CreateCityViewModel city)
        {
            City newCity = new City { Name = city.Name };
            
            _dbPeopleC.Cities.Add(newCity);
            _dbPeopleC.SaveChanges();

            return newCity;
        }

        public List<City> Read()
        {
            var query = from city in _dbPeopleC.Cities select city;
            return query.ToList();
        }

        public City Read(int id)
        {
            City readCity = (from city in _dbPeopleC.Cities select city).FirstOrDefault(city => city.CityId == id);
            return readCity;
        }

        public City Update(City city)
        {
            var query = from updateCity in _dbPeopleC.Cities where updateCity.CityId == city.CityId select updateCity;

            foreach (City data in query)
            {
                data.Name = city.Name;
            }
            _dbPeopleC.SaveChanges();
            return city;
        }
        
        public bool Delete(City city)
        {
            if (city == null)
            {
                return false;
            }
            else
            {
                var deleteCity = _dbPeopleC.Cities.Where(x => x.CityId == city.CityId).FirstOrDefault();
                if (deleteCity == null)
                {
                    return false;
                }
                else
                {
                    _dbPeopleC.Cities.Remove(deleteCity);
                    _dbPeopleC.SaveChanges();
                    return true;
                }
            }
        }
    }
}
