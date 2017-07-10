using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Connection")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}