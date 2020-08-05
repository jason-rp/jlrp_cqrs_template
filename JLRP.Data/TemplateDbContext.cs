using JLRP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JLRP.Data
{
    public class TemplateDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) 
            : base(options)
        {
            
        }

    }
}
