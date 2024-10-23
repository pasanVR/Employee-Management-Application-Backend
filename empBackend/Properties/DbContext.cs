using empBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace empBackend
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
