using BLog.IServices;
using DataAccess.Entities;

using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainApiAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService<User,UserDTO> userService;

        public UserController(BLog.IServices.IUserService<User, UserDTO> userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Register(UserDTO user)
        {
            string? value = null;
            userService.Register(user, DataAccess.Entities.User.table, value);
            return Ok();
        }
    }
}
