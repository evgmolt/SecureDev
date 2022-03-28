using System.Threading.Tasks;
using DebetCards.Models;

namespace DebetCards.Data
{
    public interface IUserRepository
    {
        Task<User?> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
        Task CreateUser(User user);
    }
}