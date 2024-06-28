using HealthPortalAPI.Data;
using HealthPortalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HealthPortalAPI.Services
{
    public class UserService : IUserService
    {
        private readonly HealthPortalDbContext _context;

        public UserService(HealthPortalDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
            return user;
        }
    }
}
