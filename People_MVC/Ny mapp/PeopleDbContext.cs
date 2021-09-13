using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People_MVC.Models.ViewModel;

namespace People_MVC.Data
{
    public class PeopleDbContext:DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //Public DbSet<People> Peoples{ get;set; }
    }
}
