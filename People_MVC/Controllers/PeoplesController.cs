using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People_MVC.Data;
using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;
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
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageRepo _personLanguageRepo;


        public PeoplesController(IPeopleService peopleService, IPeopleRepo peopleRepo, PeopleDbContext context, ICityService cityService, ILanguageService languageService, IPersonLanguageRepo personLanguageRepo)
        {
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
            _context = context;
            _cityService = cityService;
            _languageService = languageService;
            _personLanguageRepo = personLanguageRepo;

        }

        [HttpGet]
        public IActionResult Index()
        {
            //PeopleViewModel vm = new PeopleViewModel();
            // vm.people = _context.Persons.ToList();
            //return View(vm);

            //if (InMemoryPeopleRepo.allPeopleList.Count == 0)
            //{
            //    InMemoryPeopleRepo.CreateDefaultPeoples();
            //}
            //return View(_peopleService.All());


            var query = from a in _context.Persons
                        join b in _context.Cities on a.CityId equals b.CityId
                        join c in _context.Countries on b.CountryId equals c.CountryId
                        join d in _context.PersonLanguages on a.PersonId equals d.PersonId
                        join e in _context.Languages on d.LanguageId equals e.LanguageId
                        select new { PId = a.PersonId, PName = a.Name, Phone = a.TeleNumber, CityName = b.Name, CountryName = c.Name, PLanguages = d.Language.Name};

            List < dynamic> oneList = new List<dynamic> ();


            foreach (var record in _context.Persons)
            {
              int tempId = record.PersonId;
              string tempLanguage = "";

              dynamic dyObj = new ExpandoObject();
                
              foreach (var item in query.ToList())
                {
                  if (item.PId == tempId)
                    {                    
                    dyObj.PId = item.PId;
                    dyObj.PName = item.PName;
                    dyObj.Phone = item.Phone;
                    dyObj.CityName = item.CityName;
                    dyObj.CountryName = item.CountryName;
                    tempLanguage = tempLanguage + " " + item.PLanguages;
                    }
                }
                  
                    dyObj.PLanguages = tempLanguage;
                    oneList.Add(dyObj);
               }   
                   
            ViewBag.data = oneList;
            return View();
        }      

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            //    peopleViewModel.PeopleList = _peopleService.FindBy(peopleViewModel.Search);
            //    return View(peopleViewModel);

            PeopleViewModel vm = new PeopleViewModel();
            vm.people = _context.Persons.ToList();

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
            var _peoples = from u in _context.Persons
                           where u.Name.Contains(search)
                           select u;

            _peoples = _context.Persons.Where(u => u.Name == search);

            return PartialView(_peoples);
         
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
             {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
             }
                return View(new CreatePersonViewModel());
        }
       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //_peopleService.Remove(id);
            Person deletePerson = _context.Persons.Find(id);
            _context.Persons.Remove(deletePerson);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Login()
        {
            ViewBag.LoginState = "Before login...";
            return View();
        }



        //[HttpPost]
        //public ActionResult Login(FormCollection fc)
        //{
        //    string email = fc["inputEmail3"];
        //    string password = fc["inputPassword3"];
        //    var user = _context.Persons.Where(b=>b.Email & base.Password == password);
        //    if (user.Count() > 0)
        //    {
        //        ViewBag.LoginState = email + "after login...";
        //    }
        //    else
        //    {
        //        ViewBag.LoginState = email + "don't exist.";

        //    }
        //    return View();
        //}
    }
}
