using People_MVC.Data;
using People_MVC.Models.Repo;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace People_MVC.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo ;
        PeopleDbContext _peopleDb;
        ILanguageRepo _languageRepo;
        private readonly ICityRepo _cityRepo;
        private readonly IPersonLanguageRepo _personLanguageRepo;

        public static List<Person> _peopleList = new List<Person>();

        //Constructor Injection--Fetching IPeopleRepo Object from Startup ConfigureServices

        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo,IPersonLanguageRepo personLanguageRepo,PeopleDbContext peopleDb, ILanguageRepo languageRepo)
        {
            _peopleRepo = peopleRepo;
            _peopleDb = peopleDb;
            _languageRepo = languageRepo;
            _cityRepo = cityRepo;
            _languageRepo = languageRepo;
        }

        public PeopleService()
        {
            this._peopleDb = new PeopleDbContext();
        }

        public Person Add(CreatePersonViewModel person)
        {
            CreatePersonViewModel addPerson = new CreatePersonViewModel
            {
                //ID = _peopleList.Count+1,
                City = person.City,
                Name = person.Name,
                TeleNumber =person.TeleNumber
            };
            return _peopleRepo.Create(addPerson);

            City selectedCity = _cityRepo.Read(Convert.ToInt32(person.City));

            Person newPerson = new Person { Name = person.Name, City = selectedCity, TeleNumber = person.TeleNumber };
            _peopleDb.Persons.Add(newPerson);
            _peopleDb.SaveChanges();

            for (int i = 0; i < person.Languages.Length; i++)
            {
                Language selectedLanguage = _languageRepo.Read(person.Languages[i]);
                _personLanguageRepo.Create(newPerson, selectedLanguage);
            }

            return newPerson;
        }

        public PeopleViewModel All()
        {

            PeopleViewModel indexViewModel = new PeopleViewModel
            {
                People = _peopleDb.Persons.ToList()
            };
            return indexViewModel;
        }

         public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Person person = FindBy(id);
            return _peopleRepo.Delete(person);
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            //search.People = _peopleList.FindAll(
            //    person => person.Name.Contains(search.Search,StringComparison.OrdinalIgnoreCase)
            //           || person.City.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase)
            //           || person.TeleNumber.Contains(search.Search)
            //);
            List<Language> searchedLanguage = (from lang in _languageRepo.Read()
                                               where lang.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
                                               select lang)
                                                .ToList<Language>();

            search.People = _peopleRepo.Read().FindAll(
                person => person.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
                || person.City.Name.Contains(search.Search, System.StringComparison.OrdinalIgnoreCase)
                || person.PersonLanguages.Exists(pl => searchedLanguage.Exists(sl => sl.LanguageId == pl.LanguageId))
                || person.TeleNumber.Contains(search.Search)
            );

            return search;
        }

        public PersonLanguage AddToPerson(int LanguageID, int PersonID)
        {
            return _peopleRepo.AddToPerson(LanguageID, PersonID);
        }

        public Person Edit(int id, Person person)
        {
            Person personUpdate = _peopleRepo.Read(id);

            if (personUpdate != null)

            {
                return _peopleRepo.Update(person);

            }
            else
            {
                return person;
            }
        }

        public string GetCityName(int personId)
        {
            var query = from a in _peopleDb.Persons
                        join b in _peopleDb.Cities on a.CityId equals b.CityId
                        where a.PersonId == personId
                        select b.Name;
            string name = query.ToList().FirstOrDefault().ToString();
            return name;
        }

        public string GetCountryName(int personId)
        {
            var query = from a in _peopleDb.Persons
                        join b in _peopleDb.Cities on a.CityId equals b.CityId
                        join c in _peopleDb.Countries on b.CountryId equals c.CountryId
                        where a.PersonId == personId
                        select c.Name;
            string name = query.ToList().FirstOrDefault().ToString();
            return name;
        }

        public string GetPersonLanguage(int personId)
        {
            var query = from a in _peopleDb.Persons
                        join d in _peopleDb.PersonLanguages on a.PersonId equals d.PersonId
                        join e in _peopleDb.Languages on d.LanguageId equals e.LanguageId
                        where a.PersonId == personId
                        select new { PLanguage = d.Language.Name };
            string PLanguages = "";
            foreach(var item in query.ToList())
            {
                PLanguages = PLanguages + "  " + item.PLanguage;
            }
            return PLanguages;
        }
    }
}
