using People_MVC.Models.ViewModel;
using People_MVC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Repo
{
    public interface ILanguageRepo
    {
        public Language Create(CreateLanguageViewModel language);

        public Language Read(int id);
        public List<Language> Read(PersonLanguage personLanguage);
        public Language FindBy(string search);   
      
        public bool Delete(Language language);
        public Language Update(Language language);
               
    }
}
