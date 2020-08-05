using JLRP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JLRP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

    }
}
