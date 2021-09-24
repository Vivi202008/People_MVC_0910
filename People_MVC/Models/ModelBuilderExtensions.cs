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
                new Language(){LanguageId = 1,  Name = "Other" },
                new Language() { LanguageId = 2,  Name = "German"},
                new Language() { LanguageId = 3,  Name = "Italian"},
                new Language() {LanguageId = 4 , Name = "English" },
                new Language() { LanguageId = 5,  Name = "Spanish"},
                new Language() { LanguageId = 6, Name = "Chinese" },
                new Language() {  LanguageId = 7, Name = "Swedish"} 
           );

            modelBuilder.Entity<Person>().HasData(
                new Person() { PersonId = 1, Name = "King", TeleNumber = "031111111111", CityId=1 },
                new Person() { PersonId = 2,Name = "Olle", TeleNumber = "071111111111",  CityId = 1 },
                new Person() { PersonId = 3,Name = "Jenny", TeleNumber = "07333333333",  CityId = 3 },
                new Person() { PersonId = 4,Name = "Anna", TeleNumber = "071123123123",  CityId = 5 },
                new Person() { PersonId = 5,Name = "Sunny", TeleNumber = "03155555555",  CityId = 2 },
                new Person() {  PersonId = 6, Name = "Molly", TeleNumber = "07166666666",CityId = 4 },
                new Person() {  PersonId = 7,Name = "Jonnasson", TeleNumber = "0737777777", CityId = 5 },
                new Person() { PersonId = 8, Name = "Hugo", TeleNumber = "0788888888", CityId = 5 }
                );

            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage() {  PersonId = 1,LanguageId = 1 }, 
                new PersonLanguage() { LanguageId = 2, PersonId = 1 }, 
                new PersonLanguage() { LanguageId = 1, PersonId = 2 }, 
                 new PersonLanguage() { LanguageId = 6, PersonId = 2 }, 
                 new PersonLanguage() { LanguageId = 7, PersonId = 3 }, 
                new PersonLanguage() { LanguageId = 3, PersonId = 4 },
                new PersonLanguage() { LanguageId = 5, PersonId = 4 }, 
                new PersonLanguage() { LanguageId = 7, PersonId = 4 },
                new PersonLanguage() { LanguageId = 4, PersonId = 5 },
                new PersonLanguage() { LanguageId = 2, PersonId = 6 },
                new PersonLanguage() { LanguageId = 5, PersonId = 7 },
                new PersonLanguage() { LanguageId = 7, PersonId = 7 },
                new PersonLanguage() { LanguageId = 7, PersonId = 8 }
                );

            modelBuilder.Entity<City>().HasData(
                new City() {  CityId = 1,Name = "Stockholm", CountryId = 5 },
                new City() { CityId = 2, Name = "Göteborg", CountryId = 5 },
                new City() { CityId = 3,Name = "Berlin",  CountryId = 1 },
                new City() {  CityId = 4, Name = "Beijing",CountryId = 2 },
                new City() { CityId = 5, Name = "Guangzhou", CountryId = 2 },
                new City() { CityId = 6, Name = "Houston", CountryId = 3 },
                new City() { CityId = 7, Name = "Oslo", CountryId = 4 }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country() { CountryId = 1,Name = "Other"  }, 
                new Country() {  CountryId = 2 ,Name = "China"},
                new Country() { CountryId = 3 ,Name = "USA" },
                new Country() { CountryId = 4,Name = "Norway"  },
                new Country() {  CountryId = 5,Name = "Sweden" }
                );
        }
    
    }
}
