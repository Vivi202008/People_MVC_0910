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

            modelBuilder.Entity<PersonInsurance>().HasKey(ci =>
            new
            {
                ci.PersonId,
                ci.InsuranceId
            });

            modelBuilder.Entity<PersonInsurance>()
                .HasOne<Person>(ci => ci.Person)
                .WithMany(i => i.PersonInsurances)
                .HasForeignKey(ci => ci.PersonId);

            modelBuilder.Entity<PersonInsurance>()
                .HasOne<Insurance>(ci => ci.Insurance)
                .WithMany(i => i.PersonInsurances)
                .HasForeignKey(ci => ci.InsuranceId);
        }

        public DbSet<Person> Persons{ get;set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<PersonInsurance> PersonInsurances { get; set; }
    }
}
