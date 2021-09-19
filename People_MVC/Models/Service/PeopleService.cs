using People_MVC.Data;
using People_MVC.Models.Repo;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo ;
        InMemoryPeopleRepo PeopleData = new InMemoryPeopleRepo();
        public static List<Person> _peopleList = new List<Person>();

        //Constructor Injection--Fetching IPeopleRepo Object from Startup ConfigureServices

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public PeopleService()
        {
        }

        public Person Add(CreatePersonViewModel person)
        {
            CreatePersonViewModel addPerson = new CreatePersonViewModel
            {
                ID = _peopleList.Count+1,
                City = person.City,
                Name = person.Name,
                TeleNumber =person.TeleNumber
            };
            return _peopleRepo.Create(addPerson);
        }

        public PeopleViewModel All()
        {
            PeopleViewModel indexViewModel = new PeopleViewModel();
            indexViewModel.PeopleList = PeopleData.Read();
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
            search.PeopleList = _peopleRepo.Read().FindAll(
                person => person.Name.Contains(search.Search,StringComparison.OrdinalIgnoreCase)
                       || person.City.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase)
                       || person.TeleNumber.Contains(search.Search)
            );

            return search;
        }


    }
}
