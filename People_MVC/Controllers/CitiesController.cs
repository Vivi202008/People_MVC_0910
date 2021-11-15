using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using People_MVC.Models;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleMVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityservice;
        private readonly ICountryService _countryService;

        public CitiesController(ICityService cityservice, ICountryService countryService)
        {
            this._cityservice = cityservice;
            this._countryService = countryService;
        }
        public IActionResult Index()
        {
            ViewBag.Countries = new SelectList(_countryService.All().Countries, "Id", "Name");

            return View(_cityservice.All());
        }

        [HttpGet("cities/{id}")]
        public IActionResult GetCity(int id)
        {
            try
            {
                City city = _cityservice.FindBy(id);
                return PartialView("City", city);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CreateCity(string cityName, string countryName)
        {
            if (ModelState.IsValid)
            {
                _cityservice.Create(cityName,countryName);

            }

            return RedirectToAction("Index");
        }

        [HttpGet("cities/del/{id}")]
        public IActionResult DeleteCity(int id)
        {
            _cityservice.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, int countryId)
        {

            City editedCity = new City { CityId = id, Name = name, Country = { CountryId = countryId } };
            if (ModelState.IsValid)
            {
                _cityservice.Edit(id, editedCity);
            }

            return View("Index", _cityservice.All());
        }
    }
}
