using Microsoft.AspNetCore.Mvc;
using People_MVC.Models;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleMVC.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _service;


        public CountriesController(ICountryService service)
        {
            this._service = service;
        }
        public IActionResult Index()
        {
            return View(_service.All());
        }

        [HttpGet("/countries/{id}")]
        public IActionResult GetCountry(int id)
        {
            try
            {
                Country country =_service.FindBy(id);
                return PartialView("Country", country);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CreateCountry(string countryName)
        {
            _service.Add(countryName);
            return RedirectToAction("Index");
        }

        [HttpGet("/countries/del/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }



    }
}
