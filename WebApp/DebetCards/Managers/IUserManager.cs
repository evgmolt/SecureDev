using DebetCards.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebetCards.Managers
{
    public interface IUserManager
    {
        /// <summary> Возвращает пользователя по логину и паролю </summary>
        Task<User> GetUser(LoginRequest request);

        /// <summary> Создает нового пользователя </summary>
        Task<Guid> CreateUser(CreateUserRequest request);
    }
}