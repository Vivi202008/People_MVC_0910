using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;

namespace People_MVC.Controllers
{
    public class AccountsController : Controller
    {
        private IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(CreateUserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Add(user);
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.RegistrationErrorMsg = "Values are missing!";
                }
            }
            catch (CreationException e)
            {
                ViewBag.RegistrationErrorMsg = e.Message;
            }

            return View(user);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel() { ReturnUrl = "/people/peopleindex" });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
        {
            if (_userService.Login(model))
            {

                return LocalRedirect(model.ReturnUrl);
            }
            else
            {
                ViewBag.LoginErrorMsg = "Wrong username and/or password";
                return View(model);
            }

        }

        public IActionResult LogOut()
        {
            _userService.Logout();

            return RedirectToAction("Login");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UserIndex()
        {
            return View(_userService.All());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRole(string userName, string role)
        {
            try
            {
                _userService.AddRole(userName, role);

            }
            catch (CreationException e)
            {
                ViewBag.ErrorMsg = e.Message;
            }
            catch (EntityNotFoundException e)
            {
                ViewBag.ErrorMsg = e.Message;
            };

            return RedirectToAction("UserIndex");

        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
