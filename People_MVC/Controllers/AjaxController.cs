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
        PeopleService peopleService = new PeopleService();

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
                return PartialView("_Show", peopleService.All());
            }
            return PartialView(
                "_Show", peopleService.FindBy(peopleSearch));
        }
        //Get
        public IActionResult Management()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PersonDetails(int ID)
        {
            return PartialView("_PersonDetails", _peopleRepo.Read(ID));
        }
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            Person deletePerson = _peopleRepo.Read(ID);
            if (deletePerson != null)
            {
                ViewBag.Message = $"Person with id {ID} has been deleted";
                return PartialView("_Delete", _peopleRepo.Delete(deletePerson));
            }
            else
            {
                ViewBag.Message = $"person with id {ID} is not exist.";
                return PartialView("_Delete", _peopleRepo.Delete(deletePerson));
            }
            //Person deletePerson = _peopleRepo.Read(ID);
            //return PartialView("_Delete", _peopleRepo.Delete(deletePerson));
        }
    }
}