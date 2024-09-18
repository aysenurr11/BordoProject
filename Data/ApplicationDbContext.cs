using BordoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BordoProject.Data
{


    public class ApplicationDbContext:DbContext 

    {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //public object Answer { get; internal set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        



    }
}
