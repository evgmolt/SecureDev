using System.Linq;
using System.Threading.Tasks;
using DebetCards.Models;
using Microsoft.EntityFrameworkCore;

namespace DebetCards.Data
{
    internal class UserRepository: IUserRepository
    {
        private readonly CardDbContext _context;

        public UserRepository(CardDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash)
        {
            return 
                await _context.Users
                    .Where(x=> x.Username == login && x.PasswordHash == passwordHash)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}