using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILanguageService = People_MVC.Models.Service.ILanguageService;

namespace PeopleMVC.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _service;

        public LanguagesController(ILanguageService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.All());
        }

        public IActionResult CreateLanguage(CreateLanguageViewModel language)
        {
            _service.Add(language);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveLanguage(int id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");

        }

        public IActionResult FindLanguage(int id)
        {
            try
            {
                return PartialView("Language", _service.FindBy(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
