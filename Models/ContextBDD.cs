using System;
using Microsoft.EntityFrameworkCore;
namespace VaccinatorNet.Models
{
    public class ContextBDD : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Injection> Injections { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source =Vaccinator.db");
        }
    }
}
