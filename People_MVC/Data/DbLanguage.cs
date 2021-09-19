using People_MVC.Models.ViewModel;
using People_MVC.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Data
{
    public class DbLanguage
    {
        private readonly PeopleDbContext _dbPeopleC;

        public DbLanguage(PeopleDbContext PeopleDbContext)
        {
            _dbPeopleC = PeopleDbContext;
        }

        public Language Create(CreateLanguageViewModel language)
        {
            Language newLanguage = new Language();
                newLanguage.Name = language.Name;

            _dbPeopleC.Languages.Add(newLanguage);
            _dbPeopleC.SaveChanges();

            return newLanguage;
        }

        public List<Language> Read()
        {
            var query = (from language in _dbPeopleC.Languages select language).Include(c => c.PersonLanguages);

            return query.ToList();
        }

        public Language Read(int id)
        {
            Language readLanguage = (from language in _dbPeopleC.Languages select language).Include(c => c.PersonLanguages).FirstOrDefault(language => language.Id == id);

            return readLanguage;
        }

        public Language Update(Language language)
        {
            var query = from updateLanguage in _dbPeopleC.Languages where updateLanguage.Id == language.Id select updateLanguage;

            foreach (Language data in query)
            {
                data.Name = language.Name;
            }

            _dbPeopleC.SaveChanges();

            return language;
        }

        public bool Delete(Language language)
        {
            if (language == null)
            {
                return false;
            }
            else
            {
                var deleteLanguage = _dbPeopleC.Languages.Where(x => x.Id == language.Id).FirstOrDefault();
                if (deleteLanguage == null)
                {
                    return false;
                }
                else
                {
                    _dbPeopleC.Languages.Remove(deleteLanguage);
                    _dbPeopleC.SaveChanges();
                    return true;
                }
            }
        }

    }
}
