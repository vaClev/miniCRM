using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRMClasses.Models;

namespace CRMClasses
{
    internal class DBContextClass : DbContext
    {
        public DbSet<Partner> Partners { set; get; }
        public DbSet<Deal> Deals { set; get; }
        public DbSet<Contact> Contacts { set; get; }

        public DBContextClass()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data source = CRMData.db");
        }
    }
}
