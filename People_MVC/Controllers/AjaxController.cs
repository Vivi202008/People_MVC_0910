using Microsoft.AspNetCore.Mvc;
using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;


namespace People_MVC.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly IPeopleRepo _peopleRepo;

        public AjaxController(IPeopleService peopleService, IPeopleRepo peopleRepo)
        {
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
           return PartialView("_ShowAll", _peopleService.All());  
        }

        [HttpGet]
        public IActionResult Show(string searchId)
        {
            PeopleViewModel peopleSearch = new PeopleViewModel
            {
                Search = searchId
            };
            if (string.IsNullOrEmpty(peopleSearch.Search))
            {
                return PartialView("_Show", _peopleService.All());
            }
            return PartialView("_Show", _peopleService.FindBy(peopleSearch));
        }
        //Get
        public IActionResult Management()
        {
            return View();
        }

        public IActionResult PersonDetails(int ID)
        {      
            return PartialView("_PersonDetails",_peopleRepo.Read(ID));
        }

        public IActionResult Delete(int ID)
        {
            Person deletePerson = _peopleRepo.Read(ID);
            return PartialView("_PersonDetails", _peopleRepo.Delete(deletePerson));
        }

    }
}