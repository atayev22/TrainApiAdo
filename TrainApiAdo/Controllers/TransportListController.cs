using BLog.IServices;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainApiAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportListController : ControllerBase
    {

        private ITransportListService transportService;

        public TransportListController(ITransportListService transportService)
        {
            this.transportService = transportService;
        }

        //GET: api/<TransportListController>
        [HttpGet("Get")]
        public IActionResult Get()

        {
            try
            {
                DataTable transports = transportService.Get(TransportList.table);
                var serJson = JsonConvert.SerializeObject(transports);

                return Ok(serJson);

            }
            catch (Exception e)
            {

                return BadRequest(new { message = $"{e.StackTrace}" });
            }
            
        }

        // GET api/<TransportListController>/5
        [HttpGet("Get/{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            string? value = null;
            try
            {
                DataTable transport = transportService.Get(id, TransportList.table, value);
                var serJson = JsonConvert.SerializeObject(transport);

                return Ok(serJson);

            }
            catch (Exception e)
            {

                return BadRequest(new { message = $"{e.StackTrace}" });
            }
            
            

            
        }

        //POST api/<TransportListController>
        [HttpPost("Add")]
        public void Add([FromBody] TransportList transport)
        {
               string? value = null;
          
               transportService.Add(transport, TransportList.table, value);
                
        }

        // PUT api/<TransportListController>/5
        [HttpPut("Update")]
        public void Update([FromBody] TransportList transport)
        {
            string? value = null;
            transportService.Update(transport, TransportList.table, value);
        }

        // DELETE api/<TransportListController>/5
        [HttpDelete("Delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            string? value = null;
            transportService.Delete(id, TransportList.table, value);
        }
    }
}
