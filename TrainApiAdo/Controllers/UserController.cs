﻿using BLog.IServices;
using DataAccess.Entities;

using DTO;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("Register"),Authorize(Roles ="admin")]
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
            
                string? value = null;
                var jwt = userService.LogIn(user, DataAccess.Entities.User.table, value);
                if (jwt!=null)
                {
                    return Ok(jwt);
                }
                else
                {
                    return BadRequest();
                }

            
        }
    }
}
