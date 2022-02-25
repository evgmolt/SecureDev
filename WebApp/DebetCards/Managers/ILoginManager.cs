using DebetCards.Models;
using System.Threading.Tasks;

namespace DebetCards.Managers
{
    public interface ILoginManager
    {
        Task<LoginResponse> Authenticate(User user);
    }
}