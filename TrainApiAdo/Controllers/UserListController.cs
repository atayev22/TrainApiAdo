using BLog.IServices;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainApiAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        IUserListService userService;

        public UserListController(IUserListService userService)
        {
            this.userService = userService;
        }


        // GET: api/<ValuesController>
        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                var users = userService.Get(UserList.table);
                var serJson = JsonConvert.SerializeObject(users);
                return Ok(serJson);
            }
            catch (Exception e)
            {

                return BadRequest(e.StackTrace);
            }
        }

        //// GET api/<ValuesController>/5
        [HttpGet("Get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            string? value=null;

            try
            {
                var user = userService.Get(id, UserList.table, value);
                var serJson = JsonConvert.SerializeObject(user);
                return Ok(serJson);
                 
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        // POST api/<ValuesController>
        [HttpPost("Add")]
        public void Add([FromBody] UserList user)
        {
            string? value = null;
            userService.Add(user, UserList.table, value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserList user)
        {
            string? value = null;
            userService.Update(user, UserList.table, value);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("Delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            string? value = null;
            userService.Delete(id, UserList.table, value);
        }
    }
}
