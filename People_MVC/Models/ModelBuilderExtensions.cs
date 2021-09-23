using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Language>().HasData(
                new Language{ Name = "Swedish", LanguageId = 1 },
                new Language() { Name = "German", LanguageId = 2 },
                new Language() { Name = "Italian", LanguageId = 3 },
                new Language() { Name = "Mandarin", LanguageId = 4 }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person() { Name = "King", TeleNumber = "031111111111", PersonId = 1 },
                new Person() { Name = "Olle", TeleNumber = "071111111111", PersonId = 2 },
                new Person() { Name = "Jenny", TeleNumber = "07333333333", PersonId = 3 },
                new Person() { Name = "Anna", TeleNumber = "071123123123", PersonId = 4 }
                );

            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage() { LanguageId = 1, PersonId = 1 }, 
                new PersonLanguage() { LanguageId = 2, PersonId = 1 }, 
                new PersonLanguage() { LanguageId = 1, PersonId = 2 }, 
                new PersonLanguage() { LanguageId = 1, PersonId = 3 }, 
                new PersonLanguage() { LanguageId = 1, PersonId = 4 },
                new PersonLanguage() { LanguageId = 2, PersonId = 4 }, 
                new PersonLanguage() { LanguageId = 3, PersonId = 4 }
                );

            modelBuilder.Entity<City>().HasData(
                new City() { Name = "Stockholm", CityId = 1 },
                new City() { Name = "Göteborg", CityId = 2 },
                new City() { Name = "Berlin", CityId = 3 },
                new City() { Name = "Beijing", CityId = 4 },
                new City() { Name = "Guangzhou", CityId = 5 },
                new City() { Name = "Houston", CityId = 6 },
                new City() { Name = "Oslo", CityId = 7 }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country() { Name = "Sweden", CountryId = 1 },
                new Country() { Name = "China", CountryId = 2 },
                new Country() { Name = "USA", CountryId = 3 },
                new Country() { Name = "Norway", CountryId = 4 }
                );
        }
    
    }
}
