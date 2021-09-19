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
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

            public CityController(ICityService cityService)
            {
                _cityService = cityService;
            }

            public IActionResult Index(CityViewModel cityViewModel)
            {
                if (!string.IsNullOrEmpty(cityViewModel.Search))
                {
                    return View(_cityService.FindBy(cityViewModel));
                }
                else
                {
                    return View(_cityService.All());
                }
            }

            [HttpPost]
            public IActionResult Create(CreateCityViewModel city)
            {
                if (ModelState.IsValid)
                {
                    _cityService.Add(city);
                }
                return View("Index", _cityService.All());
            }

         
            [HttpGet]
            public IActionResult Delete(int id)
            {
                _cityService.Remove(id);

                return View("Index", _cityService.All());
            }
        }
}
