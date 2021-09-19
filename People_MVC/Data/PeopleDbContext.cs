using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People_MVC.Models.ViewModel;
using People_MVC.Models;
using People_MVC.Views;

namespace People_MVC.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>().HasKey(ci =>
            new
            {
                ci.PersonId,
                ci.LanguageId
            });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(ci => ci.Person)
                .WithMany(i => i.PersonLanguages)
                .HasForeignKey(ci => ci.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(ci => ci.Language)
                .WithMany(i => i.PersonLanguages)
                .HasForeignKey(ci => ci.LanguageId);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }    
    }
}
