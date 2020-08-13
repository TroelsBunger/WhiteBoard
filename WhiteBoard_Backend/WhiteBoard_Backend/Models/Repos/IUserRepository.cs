using System.Linq;
using System.Threading.Tasks;
using WhiteBoard_Backend.Shared.Models;

namespace WhiteBoard_Backend.Models.Repos
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        Task<UserDto> ReadUserAsync(long userId);

        Task<User> UserExists(string fullName, string password);
    }
}