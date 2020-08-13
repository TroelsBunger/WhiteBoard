using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public class UserRepository : IUserRepository
    {
        private WhiteBoardContext _context;

        public UserRepository(WhiteBoardContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users;

        public async Task<UserDto> ReadUserAsync(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            
            return user?.ToDto();
        }

        public async Task<User> UserExists(string fullName, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName.Equals(fullName) && u.Password == password);

            return user;
        } 
    }
}