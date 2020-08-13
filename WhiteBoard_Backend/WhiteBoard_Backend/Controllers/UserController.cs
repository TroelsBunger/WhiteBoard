using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WhiteBoard_Backend.Models;
using WhiteBoard_Backend.Models.Repos;

namespace WhiteBoard_Backend.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
       private IUserRepository _userRepository;
       private IConfiguration _config;

       public UserController(IUserRepository userRepository, IConfiguration config)
       {
           _userRepository = userRepository;
           _config = config;
       }

    }
}