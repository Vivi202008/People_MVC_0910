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
        private readonly ICountryService _countryService;
       
        public CountriesController(ICountryService service)
        {
            this._countryService = service;
        }
        public IActionResult Index()
        {
            return View(_countryService.All());
        }

        [HttpGet("/countries/{id}")]
        public IActionResult GetCountry(int id)
        {
            try
            {
                Country country = _countryService.FindBy(id);
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
            _countryService.Add(countryName);
           
            return RedirectToAction("Index");
        }

        [HttpGet("/countries/del/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            _countryService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            Country editedCountry = new Country { CountryId = id, Name = name };
            if (ModelState.IsValid)
            {
                _countryService.Edit(id, editedCountry);
            }

            return View("Index", _countryService.All());
        }

    }
}
