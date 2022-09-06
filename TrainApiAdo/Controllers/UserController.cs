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

        [HttpPost("Register")]
        public IActionResult Register(UserDTO user)
        {
            string? value = null;
            if(userService.Register(user, DataAccess.Entities.User.table, value))
            {
                return Ok("reg proshla uspeshna");
            }
            else
            {
                return BadRequest("takoy user yest");
            }
            
        }

        [HttpPost("Login")]
        public IActionResult LogIn(UserDTO user)
        {
            try
            {
                string? value = null;
                if (userService.LogIn(user, DataAccess.Entities.User.table, value)!=null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                throw new Exception($"{e.Source}");
            }
            
        }
    }
}
