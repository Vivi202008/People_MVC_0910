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
    public class ReactController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;
        readonly PeopleDbContext _context;
        private readonly IPersonLanguageRepo _personLanguageRepo;


        public ReactController(IPeopleService peopleService, IPeopleRepo peopleRepo, PeopleDbContext context, ICityService cityService, ICountryService countryService, ILanguageService languageService, IPersonLanguageRepo personLanguageRepo)
        {
            _peopleService = peopleService;
            _context = context;
            _cityService = cityService;
            _countryService = countryService;
            _languageService = languageService;
            _personLanguageRepo = personLanguageRepo;
          }

        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "CityId", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "LanguageId", "Name");

            if (!string.IsNullOrEmpty(peopleViewModel.Search))
            {
                return View(_peopleService.FindBy(peopleViewModel));
            }
            else
            {
                return View(_peopleService.All());
            }
        }

        [HttpPost]
        public IActionResult Create(string addName, string addCity, string addPhone, int[] addLanguages)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "CityId", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "LanguageId", "Name");

            City newCity = _cityService.FindBy(Convert.ToInt32(addCity));
            if (ModelState.IsValid)
            {
                Person personAdd = new Person
                {
                    Name = addName,
                    City = newCity,
                    TeleNumber = addPhone
                };
                _context.Persons.Add(personAdd);
                _context.SaveChanges();
                int newPersonId = _context.Persons.ToList().Last().PersonId;

                for (int i = 0; i < addLanguages.Length; i++)
                {
                    PersonLanguage addPersonLanguage = new PersonLanguage
                    {
                        PersonId = newPersonId,
                        LanguageId = addLanguages[i]
                    };
                    _context.PersonLanguages.Add(addPersonLanguage);
                }
            }
            _context.SaveChanges();
            return View("Index", _peopleService.All());
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string city, string phoneNumber, int[] languages)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "CityId", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "LanguageId", "Name");

            City selectedCity = _cityService.FindBy(Convert.ToInt32(city));

            Person personEdit = _peopleService.FindBy(id);
            personEdit.Name = name;
            personEdit.City = selectedCity;
            personEdit.TeleNumber = phoneNumber;
            personEdit.PersonLanguages.Clear();

            for (int i = 0; i < languages.Length; i++)
            {
                Language languageEdit = _languageService.FindBy(languages[i]);
                personEdit.PersonLanguages.Add(new PersonLanguage { PersonId = id, Person = personEdit, LanguageId = languageEdit.LanguageId, Language = languageEdit });
            }

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, personEdit);
            }
            _context.SaveChanges();
            return View("Index", _peopleService.All());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Cities = new SelectList(_cityService.All().Cities, "CityId", "Name");
            ViewBag.Languages = new SelectList(_languageService.All().Languages, "LanguageId", "Name");
            _peopleService.Remove(id);

            return View("Index", _peopleService.All());
        }

    }
}
