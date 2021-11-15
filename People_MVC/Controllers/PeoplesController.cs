using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using People_MVC.Data;
using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace People_MVC.Controllers
{
    public class PeoplesController : Controller
    {
        private readonly IPeopleService _peopleService;
        readonly IPeopleRepo _peopleRepo;
        readonly PeopleDbContext _context;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageRepo _personLanguageRepo;


        public PeoplesController(IPeopleService peopleService, IPeopleRepo peopleRepo, PeopleDbContext context, ICityService cityService, ICountryService countryService, ILanguageService languageService, IPersonLanguageRepo personLanguageRepo)
        {
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
            _context = context;
            _cityService = cityService;
            _countryService = countryService;
            _languageService = languageService;
            _personLanguageRepo = personLanguageRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<dynamic> oneList = new List<dynamic>();

            foreach (var item in _context.Persons)
            {
                dynamic dyObj = new ExpandoObject();
                dyObj.PId = item.PersonId;
                dyObj.PName = item.Name;
                dyObj.Phone = item.TeleNumber;
                dyObj.CityName = _peopleService.GetCityName(item.PersonId); 
                dyObj.CountryName = _peopleService.GetCountryName(item.PersonId);
                dyObj.PLanguages = _peopleService.GetPersonLanguage(item.PersonId);

                oneList.Add(dyObj);
            }

            ViewBag.data = oneList;

            return View();
        }

        public class CityList
        {
            public int CityListId { get; set; }
            public string CityListName { get; set; }
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm.People = _context.Persons.ToList();

            if (!string.IsNullOrEmpty(peopleViewModel.Search))
            {
                var _peoples = from u in _context.Persons
                               where u.Name == peopleViewModel.Search
                               select u;

                _peoples = _context.Persons.Where(u => u.Name == peopleViewModel.Search);

                return View(_peoples);
            }
            else
            {
                return View(_context.Persons.ToList());
            }
        }

        [HttpPost]
        public IActionResult SearchSth(string search)
        {

            List<dynamic> oneList = new List<dynamic>();

            foreach (var item in _context.Persons)
            {
                dynamic dyObj = new ExpandoObject();
                dyObj.PId = item.PersonId;
                dyObj.PName = item.Name;
                dyObj.Phone = item.TeleNumber;
                dyObj.CityName = _peopleService.GetCityName(item.PersonId);
                dyObj.CountryName = _peopleService.GetCountryName(item.PersonId);
                dyObj.PLanguages = _peopleService.GetPersonLanguage(item.PersonId);

                oneList.Add(dyObj);
            }

            List<dynamic> resultList = new List<dynamic>();
            if (search != null)
            {
                foreach (var item in oneList)
                {
                    dynamic dySearchObj = new ExpandoObject();

                    if (item.PId.ToString().Contains(search)
                        || item.PName.Contains(search)
                        || item.Phone.Contains(search)
                        || item.CityName.Contains(search)
                        || item.CountryName.Contains(search)
                        || item.PLanguages.Contains(search))
                    {
                        dySearchObj.PId = item.PId;
                        dySearchObj.PName = item.PName;
                        dySearchObj.Phone = item.Phone;
                        dySearchObj.CityName = item.CityName;
                        dySearchObj.CountryName = item.CountryName;
                        dySearchObj.PLanguages = item.PLanguages;

                        resultList.Add(dySearchObj);
                    }
                }
            }
            else
            {
                resultList = oneList;
            }

                 ViewBag.SearchData = resultList;
            
        
            return View("SearchSth");       
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "CityId", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "LanguageId", "Name");
            return View(new CreatePersonViewModel());
        }



        [HttpPost]
        public IActionResult Create(string name, int cityId, int languageId, string telephone)
        {
            
            if (ModelState.IsValid)
             {
                Person newPerson = new Person
                {
                    Name = name,
                    CityId = cityId,
                    TeleNumber = telephone
                };
                _context.Persons.Add(newPerson);
                _context.SaveChanges();
                int newPersonId = _context.Persons.ToList().LastOrDefault().PersonId;

                PersonLanguage newPersonLanguage = new PersonLanguage
                    {
                        PersonId = newPersonId,
                        LanguageId = languageId
                    };
                 _context.PersonLanguages.Add(newPersonLanguage);
                

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
             }
                return View(new CreatePersonViewModel());
        }

      
        [HttpGet("/people/del/{id}")]
        public IActionResult DeletePerson(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet("/peoples/edit/{id}")]
        public IActionResult Edit(int id)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "CityId", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "LanguageId", "Name");
            //return View(new CreatePersonViewModel());
            return View();
        }

        [HttpPost("/peoples/edit/{id}")]
        public IActionResult Edit(int id, string name, string city, string phoneNumber, int[] languages)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "CityId", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "LanguageId", "Name");

            City selectedCity = _cityService.FindBy(Convert.ToInt32(city));

            Person person = _peopleRepo.Read(id);
            ViewBag.Data = person;

            person.Name = name;
            person.City = selectedCity;
            person.TeleNumber = phoneNumber;
            person.PersonLanguages.Clear();

            for (int i = 0; i < languages.Length; i++)
            {
                Language lg = _languageService.FindBy(languages[i]);
                person.PersonLanguages.Add(new PersonLanguage { PersonId = id, Person = person, LanguageId = lg.LanguageId, Language = lg });
            }

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, person);
            }

            return View("Index", _peopleService.All());
        }

    }
}
