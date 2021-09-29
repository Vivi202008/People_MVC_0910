using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace People_MVC.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
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
                new PersonLanguage() {PersonId  = 1 ,  LanguageId= 1}, 
                new PersonLanguage() { PersonId = 1 , LanguageId = 2}, 
                new PersonLanguage() {  PersonId = 2, LanguageId = 1}, 
                 new PersonLanguage() { PersonId = 2,LanguageId = 6 }, 
                 new PersonLanguage() { PersonId = 3 ,LanguageId = 7 }, 
                new PersonLanguage() { PersonId = 4 ,LanguageId = 3  },
                new PersonLanguage() {PersonId = 4 , LanguageId = 5 }, 
                new PersonLanguage() {  PersonId = 4 ,LanguageId = 7 },
                new PersonLanguage() { PersonId = 5 ,LanguageId = 4  },
                new PersonLanguage() {PersonId = 6 , LanguageId = 2  },
                new PersonLanguage() { PersonId = 7 ,LanguageId = 5  },
                new PersonLanguage() { PersonId = 7 ,LanguageId = 7  },
                new PersonLanguage() { PersonId = 8 , LanguageId = 7 }
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

            modelBuilder.Entity<Language>().HasData(
               new Language() { LanguageId = 1, Name = "Other" },
               new Language() { LanguageId = 2, Name = "German" },
               new Language() { LanguageId = 3, Name = "Italian" },
               new Language() { LanguageId = 4, Name = "English" },
               new Language() { LanguageId = 5, Name = "Spanish" },
               new Language() { LanguageId = 6, Name = "Chinese" },
               new Language() { LanguageId = 7, Name = "Swedish" }
          );
        }
    
    }

    //public class PeoplenDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public PeoplenDbContext(DbContextOptions<PeoplenDbContext> options)
    //        : base(options)
    //    {
    //    }

    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);

    //        IdentityRole roleAdmin = new IdentityRole()
    //        {
    //            Id = "438db5c8-0513-43a0-a84c-cd416c4e3a54",
    //            Name = "Admin",
    //            NormalizedName = "ADMIN"
    //        };
    //        IdentityRole roleUser = new IdentityRole()
    //        {
    //            Id = "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
    //            Name = "User",
    //            NormalizedName = "USER"
    //        };

    //        builder.Entity<IdentityRole>().HasData(
    //          roleAdmin, roleUser);


    //        PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

    //        ApplicationUser admin = new ApplicationUser
    //        {
    //            Id = "2ca248b4-6be8-4eca-88c8-ae952f3be531",
    //            UserName = "admin",
    //            NormalizedUserName = "ADMIN",
    //            //Age = 55,
    //            //City = "Göteborg",
    //            //Country = "Sweden",
    //            FirstName = "Joe",
    //            LastName = "Jonasson",
    //            Email = "admin@admin.com",
    //            Birthday = new DateTime(2001,01,01)
    //        };

    //        admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");

    //        builder.Entity<ApplicationUser>().HasData(
    //            admin
    //        );

    //        builder.Entity<IdentityUserRole<string>>().HasData(
    //            new IdentityUserRole<string>
    //            {
    //                RoleId = roleAdmin.Id,
    //                UserId = admin.Id
    //            },
    //            new IdentityUserRole<string>
    //            {
    //                RoleId = roleUser.Id,
    //                UserId = admin.Id
    //            }
    //        );
    //    }
    //}
}
