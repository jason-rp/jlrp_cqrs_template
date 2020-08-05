using System;
using System.Threading.Tasks;
using JLRP.Data.IRepositories;
using JLRP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JLRP.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TemplateDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<bool> EmailExistAsync(string email)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
