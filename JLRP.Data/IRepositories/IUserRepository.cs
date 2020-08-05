using System.Threading.Tasks;
using JLRP.Domain.Models;

namespace JLRP.Data.IRepositories
{
    public interface IUserRepository :IRepository<User>
    {
        Task<bool> EmailExistAsync(string email);
    }
}
