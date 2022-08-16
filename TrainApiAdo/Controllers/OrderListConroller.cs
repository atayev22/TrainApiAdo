﻿using BLog.IServices;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainApiAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListConroller : ControllerBase
    {
        IOrderListService orderService;

        public OrderListConroller(IOrderListService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/<OrderListConroller>
        [HttpGet("Get")]
        public IActionResult Get()
        {

            try
            {
                var oreders = orderService.Get(OrderList.table);
                var serJson=JsonConvert.SerializeObject(oreders);
                return Ok(serJson);
            }
            catch (Exception e)
            {

                return BadRequest(e.StackTrace);
            }
        }

        // GET api/<OrderListConroller>/5
        [HttpGet("Get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            string? value = null;
            try
            {
                var order = orderService.Get(id, OrderList.table, value);
                var serJson=JsonConvert.SerializeObject(order);
                return Ok(serJson);
            }
            catch (Exception e)
            {

                return BadRequest(e.StackTrace);
            }
        }

        // POST api/<OrderListConroller>
        [HttpPost("Add")]
        public void Add([FromBody] OrderList order)
        {
            string? value = null;
            orderService.Add(order, OrderList.table, value);
        }

        // PUT api/<OrderListConroller>/5
        [HttpPut("Update")]
        public void Update([FromBody] OrderList order)
        {
            string? value = null;
            orderService.Update(order, OrderList.table, value);
        }

        // DELETE api/<OrderListConroller>/5
        [HttpDelete("Delete/{id}")]
        public void Delete([FromRoute] int id)
        {
            string? value = null;
            orderService.Delete(id, OrderList.table, value);
        }
    }
}
