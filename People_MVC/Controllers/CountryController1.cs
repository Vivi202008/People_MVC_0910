using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Controllers
{
    public class CountryController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
