using Microsoft.EntityFrameworkCore;

namespace JLRP.Data
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            
        }


    }
}
