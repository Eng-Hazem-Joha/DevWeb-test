using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTest.Models
{
    public class CompanyContext : DbContext 
    {

        public CompanyContext(DbContextOptions <CompanyContext> options)
            :base(options)
        {
          
        }

        public DbSet <Department>  Departments { set; get; }

        public DbSet <Employee>    Employees  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(p => p.Employees);

            modelBuilder.Entity<Employee>()
                .HasOne(o => o.Department);
        }


    }
}
