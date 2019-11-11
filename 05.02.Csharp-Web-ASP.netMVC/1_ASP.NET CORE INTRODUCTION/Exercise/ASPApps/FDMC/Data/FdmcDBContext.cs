using FDMC.Models;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Data
{
    public class FdmcDBContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
        
        public FdmcDBContext(DbContextOptions<FdmcDBContext> options) : base(options)
        {

        }
    }
}
