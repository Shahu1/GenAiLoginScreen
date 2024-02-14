using System.Threading.Tasks;
using UserLogin.Models;

namespace UserLogin.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}