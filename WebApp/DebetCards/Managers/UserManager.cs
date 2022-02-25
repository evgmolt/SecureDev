using DebetCards.Data;
using DebetCards.Managers;
using DebetCards.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DebetCards.Managers
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepository _userRepo;

        public UserManager(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetUser(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);

            return user;
        }

        public async Task<Guid> CreateUser(CreateUserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                PasswordHash = GetPasswordHash(request.Password),
            };

            await _userRepo.CreateUser(user);

            return user.Id;
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}