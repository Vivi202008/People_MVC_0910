using Microsoft.AspNetCore.Mvc;
using People_MVC.Data;
using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Controllers
{
    public class PeoplesController : Controller
    {
        private readonly IPeopleService _peopleService;
        IPeopleRepo _peopleRepo;
        PeopleDbContext _context;


        public PeoplesController(IPeopleService peopleService, IPeopleRepo peopleRepo, PeopleDbContext context)
        {
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
            _context=context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm.PeopleList = _context.People.ToList();
            if (InMemoryPeopleRepo.allPeopleList.Count == 0)
            {
                InMemoryPeopleRepo.CreateDefaultPeoples();
            }
            //return View(_peopleService.All());
            return View(vm);
        }

        public PartialViewResult ListOfPeople()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            //    peopleViewModel.PeopleList = _peopleService.FindBy(peopleViewModel.Search);
            //    return View(peopleViewModel);

            PeopleViewModel vm = new PeopleViewModel();
            vm.PeopleList = _context.People.ToList();

            if (!string.IsNullOrEmpty(peopleViewModel.Search))
            {
                return View(_peopleService.FindBy(peopleViewModel));
            }
            else
            {
                return View(_peopleService.All());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
                    {
                        Person person1 = _peopleRepo.Create(person);
                        _ = person1;
                        return RedirectToAction(nameof(Index));
                    }
                return View(new CreatePersonViewModel());
        }
       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);
            return View("Index", _peopleService.All());
        }
    }
}
