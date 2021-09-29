using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    public interface IUserService
    {
        UserViewModel Add(CreateUserViewModel person);

        UserViewModel All();

        UserViewModel FindBy(string userName);

        UserViewModel Edit(string id, CreateUserViewModel person);

        bool Remove(int id);

        void AddRole(string userName, string role);
        bool Login(LoginViewModel login);

        void Logout();
    }
}
