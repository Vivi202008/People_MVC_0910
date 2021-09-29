using System.ComponentModel.DataAnnotations;

namespace People_MVC.Models.ViewModel

{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ReturnUrl { get; set; }

        public bool RememberLogin { get; set; }

        public LoginViewModel()
        {

        }
        public LoginViewModel(string password, string username)
        {
            UserName = username;
            Password = password;
        }
    }
}