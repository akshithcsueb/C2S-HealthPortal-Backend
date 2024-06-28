using HealthPortalAPI.Models;
using System.Threading.Tasks;

namespace HealthPortalAPI.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
