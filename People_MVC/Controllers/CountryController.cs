using Microsoft.AspNetCore.Mvc;
using People_MVC.Models;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index(CountryViewModel countryViewModel)
        {
            if (!string.IsNullOrEmpty(countryViewModel.Search))
            {
                return View(_countryService.FindBy(countryViewModel));
            }
            else
            {
                return View(_countryService.All());
            }
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel country)
        {
            if (ModelState.IsValid)
            {
                _countryService.Add(country);
            }
            return View("Index", _countryService.All());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _countryService.Remove(id);

            return View("Index", _countryService.All());
        }
    }
}
