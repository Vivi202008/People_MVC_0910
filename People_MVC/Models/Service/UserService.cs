using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using People_MVC.Models.Service;
using People_MVC.Data;

namespace People_MVC.Models.Service
    {
        public class UserService : IUserService
        {

            private static UserManager<ApplicationUser> _userManager;
            private static SignInManager<ApplicationUser> _signInManager;
            private static RoleManager<IdentityRole> _roleManager;
            
        public UserService(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
            {

                _signInManager = signInManager;
                _userManager = userManager;
                _roleManager = roleManager;
            }


            public UserViewModel Add(CreateUserViewModel user)
            {
                ApplicationUser createdUser = GetUserFromModel(user);

                IdentityResult result = _userManager.CreateAsync(createdUser, user.Password).Result;

                if (result.Succeeded)
                {
                    AddRole(user.UserName, "User");
                }
                else
                {
                    string errorMsgs = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMsgs += error.Description + ", ";
                    }
                    throw new CreationException(errorMsgs);
                }


                return GetModelFromUser(createdUser);
            }

            private static UserViewModel GetModelFromUser(ApplicationUser user)
            {

                UserViewModel model = new UserViewModel()
                {
                    UserName = user.UserName,
                    FullName = user.FirstName + " " + user.LastName,
                    Email = user.Email,
                    Birthday = user.Birthday,
                    Id = user.Id,
                    Roles = _userManager.GetRolesAsync(user).Result.ToList()
                };

                return model;
            }

            private static ApplicationUser GetUserFromModel(CreateUserViewModel user)
            {
                ApplicationUser createdUser = new ApplicationUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Birthday = user.Birthday
                    
                };

                return createdUser;

            }

            public static async Task<List<UserViewModel>> GetUsers()
            {
                return await _userManager.Users.Select(user => GetModelFromUser(user)).ToListAsync();
            }

           public UserViewModel Edit(string id, CreateUserViewModel person)
            {
                throw new NotImplementedException();
            }

            public UserViewModel FindBy(string userName)
            {
                ApplicationUser user = _userManager.FindByNameAsync(userName).Result;

                if (user != null)
                {
                    return GetModelFromUser(user);
                }
                else
                {
                    throw new EntityNotFoundException();
                }
            }

            public async Task<ApplicationUser> Login(string username)
            {
                return await _userManager.FindByNameAsync(username);
            }

            public bool Login(LoginViewModel login)
            {

                ApplicationUser user = Login(login.UserName).Result;

                if (user != null)
                {
                    var signInResult = _signInManager.PasswordSignInAsync(user, login.Password, true, false);
                    return signInResult.Result.Succeeded;
                }
                return false;
            }

            public async void LogoutAsync()
            {
                await _signInManager.SignOutAsync();
            }

            public bool Remove(int id)
            {
                throw new NotImplementedException();
            }

            public void Logout()
            {
                LogoutAsync();
            }

            public void AddRole(string userName, string role)
            {
                ApplicationUser user = _userManager.FindByNameAsync(userName).Result;

                if (user != null)
                {
                    if (!_roleManager.RoleExistsAsync(role).Result)
                    {
                        _roleManager.CreateAsync(new IdentityRole(role));
                    }

                    if (!_userManager.AddToRoleAsync(user, role.ToUpper()).Result.Succeeded)
                    {
                        throw new CreationException("Role could not be added to user");
                    }
                }
                else
                {
                    throw new EntityNotFoundException("User not found");
                }
            }

       public UserViewModel All()
        {
            //UserViewModel Users = new UserViewModel
            //{
            //    Users = _peopleDb.Users.ToList()
            //};
            //return Users;
            throw new NotImplementedException();
        }
    }
    }
