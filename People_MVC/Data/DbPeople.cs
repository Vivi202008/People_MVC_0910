using Microsoft.EntityFrameworkCore;
using People_MVC.Models;
using People_MVC.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Data
{
    public class DbPeople : IPeopleRepo
    {
        private readonly PeopleDbContext _dbPeopleC;
        private readonly ICityRepo _cityRepo;
        private readonly ILanguageRepo _languageRepo;
        private readonly IPersonLanguageRepo _personLanguageRepo;

        public DbPeople(PeopleDbContext peopleDbContext, ICityRepo cityRepo, ILanguageRepo languageRepo, IPersonLanguageRepo personLanguageRepo)
        {
            _dbPeopleC = peopleDbContext;
            _cityRepo = cityRepo;
            _languageRepo = languageRepo;
            _personLanguageRepo = personLanguageRepo;
        }

        public Person Create(CreatePersonViewModel person)  //?Person person
        {
            City selectedCity = _cityRepo.Read(Convert.ToInt32(person.City));

            Person newPerson = new Person();
            newPerson.Name = person.Name;
            newPerson.City = selectedCity;
            newPerson.TeleNumber = person.TeleNumber;

            _dbPeopleC.People.Add(newPerson);
            _dbPeopleC.SaveChanges();

            for (int i = 0; i < person.Languages.Length; i++)
            {
                Language selectLanguage = _languageRepo.Read(person.Languages[i]);
                _personLanguageRepo.Create(newPerson, selectLanguage);
            }

            return newPerson;
        }

        public bool Delete(Person person)
        {
            if (person == null)
            {
                 return false;
            }
            else
            {
               var deletePerson = _dbPeopleC.People.Where(x => x.ID == person.ID).FirstOrDefault();
                if (deletePerson == null)
                {
                     return false;
                }
                else
                {
                   _dbPeopleC.People.Remove(deletePerson);
                    _dbPeopleC.SaveChanges();
                    return true;
                }
            }
        }

        public List<Person> Read()
        {
            return _dbPeopleC.People.Include(people => people.City).AsParallel().ToList();
        }

        public Person Read(int id)
        {
            return _dbPeopleC.People.Include(people => people.City).FirstOrDefault(person => person.ID == id);
        }

        public Person Update(Person person)
        {
            var updatePerson = _dbPeopleC.People.FirstOrDefault(p => p.ID == person.ID);
            if (updatePerson != null)
            {
                _dbPeopleC.Entry(updatePerson).CurrentValues.SetValues(person);
            }
            return person;
        }
    }
}
