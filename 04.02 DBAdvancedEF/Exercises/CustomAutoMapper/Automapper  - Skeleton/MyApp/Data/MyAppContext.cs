
using MyApp.Core;

namespace MyApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MyAppContext : DbContext
    {
        public MyAppContext()
        {
        }

        public MyAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
