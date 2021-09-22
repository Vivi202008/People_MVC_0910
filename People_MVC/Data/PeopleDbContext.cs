using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People_MVC.Models.ViewModel;
using People_MVC.Models;



namespace People_MVC.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {   
            //initialization
        }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PeopleDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Person> Persons{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>().HasKey(ci =>
            new
            {
                ci.PersonId,
                ci.LanguageId
            });

            modelBuilder.Entity<Person>()
                .HasOne(mbo => mbo.City);

            modelBuilder.Entity<City>()
                 .HasMany(mbm => mbm.People);

            modelBuilder.Entity<City>()
                .HasOne(mbo => mbo.Country);

            modelBuilder.Entity<Country>()
                .HasMany(mbm => mbm.Cities);

            modelBuilder.Entity<PersonLanguage>()
                .HasKey(mb => mb.PLanguageId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(ci => ci.Person)
                .WithMany(ci => ci.PersonLanguages)
                .HasForeignKey(ci => ci.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(ci => ci.Language)
                .WithMany(i => i.PersonLanguages)
                .HasForeignKey(ci => ci.LanguageId);

             
        }


    }
}
