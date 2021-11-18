using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People_MVC.Data;
using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.Service;
using System;
using System.Collections.Generic;

namespace People_MVC.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]

   public class ReactFrontend : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;
        private readonly ILanguageRepo _languageRepo;
        private readonly IPeopleRepo _peopleRepo;

        public ReactFrontend(PeopleDbContext db, IPeopleRepo peopleRepo, ICityRepo cityRepo,
            ICountryRepo countryRepo, ILanguageRepo languageRepo, IPeopleService peopleService)
        {
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
            _languageRepo = languageRepo;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new
            {
                cities = _cityRepo.Read(),
                countries = _countryRepo.Read(),
                languages = _languageRepo.Read(),
                people = _peopleRepo.Read()
            };
            return Json(result);
        }

        [HttpPost]
        public ActionResult<Person> Post(CreatePersonViewModel person)
        {
            return (_peopleRepo.Create(person));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CreatePersonViewModel person)
        {
            City selectedCity = _cityRepo.Read(Convert.ToInt32(person.City));

            Person personToEdit = _peopleService.FindBy(id);
            personToEdit.Name = person.Name;
            personToEdit.City = selectedCity;
            personToEdit.TeleNumber = person.TeleNumber;
            personToEdit.PersonLanguages.Clear();

            for (int i = 0; i < person.Languages.Length; i++)
            {
                Language languageEdit = _languageRepo.Read(person.Languages[i]);
                personToEdit.PersonLanguages.Add(
                    new PersonLanguage
                    {
                        PersonId = id,
                        Person = personToEdit,
                        LanguageId = languageEdit.LanguageId,
                        Language = languageEdit
                    }
                 );
            }

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, personToEdit);
            }

            return new JsonResult(_peopleRepo.Read());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);
            return NoContent();
        }


    }
}
